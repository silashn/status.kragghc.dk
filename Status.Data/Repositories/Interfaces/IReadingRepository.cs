using Status.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Data.Repositories.Interfaces
{
    public interface IReadingRepository
    {
        Reading GetLatestReading();
        Reading GetReading(int id);
        List<Reading> GetReadings();
        List<Reading> GetReadings(DateTime from);
        List<Reading> GetReadings(DateTime from, DateTime to);
        List<Reading> GetReadings(int recent);


        void CreateReading(Reading reading);
    }
}
