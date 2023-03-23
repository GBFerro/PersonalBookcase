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

        public Author(string name, int year, string about, string footer) : base(name, year)
        {
            About = about;
            Footer = footer;
        }

        public override string ToString()
        {
            return $"{this.Name} | {this.BirthYear} |{this.About} | {this.Footer}";
        }
    }
}
