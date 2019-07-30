using System;
using System.Collections.Generic;
using static System.Console;

namespace PacktLibrary
{
    public partial class Person : IComparable<Person>

    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // test concat
        public string Concated => string.Concat(Name, DateOfBirth.ToString());

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        // 'multuply' methods
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        // operator for multiplying
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        // method with local function
        public static int Factorial(int number)
        {
            if(number < 0)
            {
                throw new ArgumentException(
                    $"{nameof(number)} cannot be less than zero");
            }
            return localFactorial(number);

            int localFactorial(int localNumber)
            {
                if (localNumber < 1)
                {
                    return 1;
                }
                return localNumber * localFactorial(localNumber - 1);
            }
        }
        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }



        // event
        public event EventHandler Shout;

        // field
        public int AngerLevel;

        // method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // if somebody listens us...
                //... then event raises
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
