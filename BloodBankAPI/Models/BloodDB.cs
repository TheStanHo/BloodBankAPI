using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankAPI.Models
{
    public class BloodDB
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool donor {get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string bloodType { get; set; }
        public string NHSNumber { get; set; }

    }
}
