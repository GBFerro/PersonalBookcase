using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookcase
{
    internal class Author : Person
    {
        public string About { get; set; }
        public string Footer { get; set; }

        public Author(string name, int year) : base(name, year)
        {
        }
    }
}
