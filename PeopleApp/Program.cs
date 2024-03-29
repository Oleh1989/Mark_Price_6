﻿using System;
using PacktLibrary;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        delegate int DelegateWithMatchingSignature(string s);
        static void Main(string[] args)
        {
            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill" };

            var baby1 = mary.ProcreateWith(harry);
            var baby2 = Person.Procreate(harry, jill);

            // call operator
            var baby3 = harry * mary;

            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine($"{mary.Name}'s first child is named \"{mary.Children[0].Name}\"");

            WriteLine(new string('-', 50));
            WriteLine($"5! is {Person.Factorial(5)}");

            // delegates
            WriteLine(new string('-', 50));
            var p1 = new Person();
            int answer = p1.MethodIWantToCall("Frog");
            WriteLine(answer);

            var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall);
            int answer2 = d("Frog");
            WriteLine(answer2);

            WriteLine(new string('-', 50));
            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            WriteLine(new string('-', 50));
            Person[] people =
            {
                new Person{Name="Simon"},
                new Person{Name="Jenny"},
                new Person{Name="Adam"},
                new Person{Name="Richard"}
            };

            WriteLine("Initial list for people");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use PersonComparer's IComparer implementation to sort");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine(new string('-', 50));

            var t = new Thing();
            t.Data = 42;
            WriteLine($"Thing : {t.Process("42")}");

            // generic
            var gt = new GenericThing<int>();
            gt.Data = 42;
            WriteLine($"Generic thing: {gt.Process("42")}");

            WriteLine(new string('-', 50));
            Employee e1 = new Employee
            {
                Name = "John Jones",
                HireDate = new DateTime(1990, 7, 28)
            };
            e1.WriteToConsole();

            WriteLine(new string('-', 50));
            WriteLine(e1.ToString());


            WriteLine(new string('-', 50));
            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123"
            };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee e2 = (Employee)aliceInPerson;
            }

            Employee e3 = aliceInPerson as Employee;
            if (e3 != null)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
            }

            WriteLine(new string('-', 50));
            try
            {
                e1.TimeTravel(new DateTime(1999, 12, 31));
                e1.TimeTravel(new DateTime(1950, 12, 25));
            }
            catch (PersonException ex)
            {

                WriteLine(ex.Message);
            }
            WriteLine(new string('-', 50));
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            WriteLine($"{email1} is a valid e-mail address: " +
                $"{email1.IsValidEmail()}");
            WriteLine($"{email2} is a valid e-mail address: " +
                $"{email2.IsValidEmail()}");

        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}
