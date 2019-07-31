using System;
using System.Collections.Generic;
using System.Text;

namespace PacktLibrary
{
    public class PersonException : Exception
    {
        public PersonException() : base() { }
        public PersonException(string message) : base(message) { }
        public PersonException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
