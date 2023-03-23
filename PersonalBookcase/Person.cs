using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookcase
{
    internal class Person
    {
        public string Name { get; set; }

        public int BirthYear { get; set; }

        public Person(string name, int birthYear)
        {
            this.Name = name;
            this.BirthYear = birthYear;
        }
    }
}
