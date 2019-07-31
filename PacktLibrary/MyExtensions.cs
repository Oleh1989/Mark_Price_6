using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PacktLibrary
{
    public static class MyExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // use simple RegExp for current input contains valid email check
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}
