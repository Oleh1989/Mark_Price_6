using System;
using System.Collections.Generic;
using System.Text;

namespace PacktLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Compare Name fields' length...
            int temp = x.Name.Length.CompareTo(y.Name.Length);

            // ... if they are equal...
            if (temp == 0)
            {
                // ... compare by the names
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // ... compare by the length
                return temp;
            }
        }
    }
}
