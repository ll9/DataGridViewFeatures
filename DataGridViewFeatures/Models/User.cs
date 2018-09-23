using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewFeatures.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    class User
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public DateTime Birthday { get; set; }

    }
}
