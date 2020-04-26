using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CapitaliseLettersInString
{
    #region Task Description
    //Your task is to convert strings to how they would be written by Jaden Smith. The strings are actual quotes from Jaden Smith,
    // but they are not capitalized in the same way he originally typed them.
    // https://www.codewars.com/kata/5390bac347d09b7da40006f6/train/csharp
    //    Example:

    // Not Jaden-Cased: "How can mirrors be real if our eyes aren't real"
    // Jaden - Cased:     "How Can Mirrors Be Real If Our Eyes Aren't Real"

    //Link to Jaden's former Twitter account @officialjaden via archive.org
    //      Fundamentals
    //      Strings
    //      Arrays
    #endregion
    public class Worker
    {
        public void Start()
        {
            string text = ToJadenCase("How can mirrors be real if our eyes aren't real");
            
            Console.WriteLine(text);
            string test = ToJadenCase(Console.ReadLine());
            Console.WriteLine(test);
        }

        public static string ToJadenCase(string text)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(text);
        }
    }
}
