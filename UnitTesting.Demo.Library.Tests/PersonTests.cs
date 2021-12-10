using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Demo.Library.Tests
{
    [TestFixture]
    public class PersonTests
    {
        const string _firstName = "Jan";
        const string _lastName = "Kowalski";
        const int _birthYear = 2000;
        private Person _person;

        [SetUp]
        public void CreateTestPerson()
        {
            _person = new Person(_firstName, _lastName, _birthYear);
        }

        [Test]
        [Order(1)]
        public void Constructor_WhenCalled_ShouldInitializeProperties()
        {
            // arrange
            const string firstName = "Jan";
            const string lastName = "Kowalski";
            const int birthYear = 2000;

            // act
            Person person = new Person(firstName, lastName, birthYear);

            // assert
            Assert.AreEqual(firstName, person.FirstName, "checking FirstName");
            Assert.AreEqual(lastName, person.LastName, "checking LastName");
            Assert.AreEqual(birthYear, person.BirthYear, "checking BirthYear");
        }

        [Test]
        [Order(2)]
        [Ignore("Replaced by the test new test")]
        public void FullName_WhenCalled_ShouldReturnProperName()
        {
            // arrange
            string expectedFullName = $"{_firstName} {_lastName}";

            // act
            string actualFullName = _person.FullName;

            // assert
            Assert.AreEqual(expectedFullName, actualFullName);
        }

        [Test]
        [Order(3)]
        [TestCase("Jan", "Kowalski")]
        [TestCase("Anna", "Nowak")]
        public void FullName_WhenCalled_ShouldReturnProperName(string firstName, string lastName)
        {
            // arrange
            const int birthYear = 2000;
            string expectedFullName = $"{firstName} {lastName}";
            Person person = new Person(firstName, lastName, birthYear);

            // act
            string actualFullName = person.FullName;

            // assert
            Assert.AreEqual(expectedFullName, actualFullName);
        }

        [Test]
        [Order(4)]
        [TestCaseSource(nameof(Age_TestData))]
        public void Age_WhenBirthYearBeforeOrEqualCurrentYear_ShouldCalculateProperAge(int birthYear, int currentYear, int expectedAge)
        {
            // arrange
            const string firstName = "Jan";
            const string lastName = "Kowalski";
            Person person = new Person(firstName, lastName, birthYear);

            // act
            int actualAge = person.Age(currentYear);

            // assert
            Assert.That(actualAge, Is.EqualTo(expectedAge));
        }

        [Test]
        public void Age_WhenBirthYearAfterCurrentYear_ShouldThrowException()
        {
            // arrange
            const int currentYear = 1999;

            // act
            // assert
            Assert.Throws<ArgumentException>(() => _person.Age(currentYear));
        }

        private static IEnumerable Age_TestData
        {
            get
            {
                yield return new TestCaseData(2000, 2001, 1).SetName("Age_WhenProperCurrentYear_ShouldCalculateProperAge - 1st case");
                yield return new TestCaseData(2000, 2018, 18).SetName("Age_WhenProperCurrentYear_ShouldCalculateProperAge - 2nd case");
                yield return new TestCaseData(2000, 2021, 21);
            }
        }
    }
}
