using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Status.Data.Contexts;
using Status.Data.Models;
using Status.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace Status.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("C:/Data/Tasks/status.kragghc.dk/Logger/Config/AppSettings.json", false);
            IConfigurationRoot configuration = builder.Build();
            DbContextOptions<StatusDbContext> options = new DbContextOptionsBuilder<StatusDbContext>().UseSqlServer(configuration.GetConnectionString("status.kragghc.dk"), o => o.MigrationsAssembly("Status.Data")).Options;
            ReadingRepository readingRepository = new ReadingRepository(options);

            PerformanceCounter CPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter RAMCounter = new PerformanceCounter("Memory", "Available MBytes");
            ManagementObject Disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");

            ObjectQuery ObjectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectSearcher ObjectSearcher = new ManagementObjectSearcher(ObjectQuery);
            ManagementObjectCollection ObjectCollection = ObjectSearcher.Get();

            dynamic value1 = CPUCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            dynamic value2 = CPUCounter.NextValue();
            int cpuPercentage = Convert.ToInt16(value2);


            Reading reading = new Reading()
            {
                CPU = cpuPercentage,
                Created = DateTime.Now,
                RAM = Convert.ToDouble(RAMCounter.NextValue())
            };

            List<Disk> Disks = new List<Disk>();

            foreach(ManagementObject disk in ObjectCollection)
            {
                Disk newDisk = new Disk()
                {
                    Name = disk["Name"].ToString(),
                    DeviceID = disk["DeviceID"].ToString(),
                    Size = Convert.ToInt64(disk["Size"]),
                    FreeSpace = Convert.ToInt64(disk["FreeSpace"]),
                    ReadingID = reading.ID
                };
                Disks.Add(newDisk);
            }

            reading.Disks = Disks;

            readingRepository.CreateReading(reading);

            Reading newReading = readingRepository.GetLatestReading();
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if(decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if(value < 0) { return "-" + SizeSuffix(-value); }
            if(value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if(Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
    }
}
