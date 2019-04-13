using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Data.Models
{
    public class Reading
    {
        public int ID { get; set; }
        public string Time { get; set; }
        public DateTime Created { get; set; }
        public int CPU { get; set; }
        public double RAM { get; set; }
        public List<Disk> Disks { get; set; }
    }
}
