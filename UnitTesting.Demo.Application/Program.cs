using System;
using UnitTesting.Demo.Library;

namespace UnitTesting.Demo.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Jan", "Kowalski", 2000);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
            Console.WriteLine(person.Age(2021));
            Console.WriteLine(person.FullName);
        }
    }
}
