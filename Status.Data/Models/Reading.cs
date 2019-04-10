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
        public decimal CPU { get; set; }
        public decimal RAM { get; set; }
        public decimal Disk { get; set; }
    }
}
