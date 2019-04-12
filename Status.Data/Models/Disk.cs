using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Data.Models
{
    public class Disk
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DeviceID { get; set; }
        public long Size { get; set; }
        public long FreeSpace { get; set; }
        public int ReadingID { get; set; }
        public Reading Reading { get; set; }
    }
}
