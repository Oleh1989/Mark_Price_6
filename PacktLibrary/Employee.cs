using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace PacktLibrary
{
    public class Employee : Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }
        public new void WriteToConsole()
        {
            WriteLine($"{Name}'s birth date is {DateOfBirth:dd/MM/yy} " +
                $"and hire date was {HireDate:dd/MM/yy}");
        }

        public override string ToString()
        {
            return $"{Name}'s code is {EmployeeCode}";
        }
    }
}
