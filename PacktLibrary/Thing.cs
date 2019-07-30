using System;
using System.Collections.Generic;
using System.Text;

namespace PacktLibrary
{
    public class Thing
    {
        public object Data = default(object);
        public string Process(string input)
        {
            if (Data == input)
            {
                return Data.ToString() + Data.ToString();
            }
            else
            {
                return Data.ToString();
            }
        }
    }
}
