using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Demo.Library
{
    public class Person
    {
        public string FirstName { get; } // Jan
        public string LastName { get; } // Kowalski
        public int BirthYear { get; } // 2000

        public Person(string firstName, string lastName, int birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public int Age(int currentYear)
        {
            if (BirthYear > currentYear)
            {
                throw new ArgumentException();
            }

            return currentYear - BirthYear;
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
