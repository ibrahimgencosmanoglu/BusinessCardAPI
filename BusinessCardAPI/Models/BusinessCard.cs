using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardAPI.Models
{
    public class BusinessCard
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string email { get; set; }
        public int number { get; set; }
    }
}
