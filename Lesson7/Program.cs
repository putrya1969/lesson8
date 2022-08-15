using System;
using System.Linq;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first string");
            var firstString = Console.ReadLine();
            Console.WriteLine("Enter second string");
            var secondString = Console.ReadLine();
            var compareResult = firstString.Equals(secondString) ? "String is equals" : "Strings not equal";
            Console.WriteLine(compareResult);
            Console.WriteLine("Enter variable string");
            var userInput = Console.ReadLine();
            Console.WriteLine(userInput.GetTotalCounts());
            Console.WriteLine($"Sorted string: {userInput.Sort()}");
            var duplicate = userInput.Duplicate();
            Console.WriteLine("Duplicated chars in string:");
            foreach (var item in duplicate)
                Console.WriteLine(item);
            Console.ReadKey();
        }

    }

    public static class StringExtension
    {
        public static bool Equals(this string source, string target)
        {
            if (source.Length != target.Length)
                return false;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                    return false;
            }
            return true;
        }

        public static int GetAlphabeticCount(this string source)
        {
            return source.Count(c => Char.IsLetter(c));
        }

        public static int GetDigitalCount(this string source)
        {
            return source.Count(c => Char.IsDigit(c));
        }

        public static int GetSpecifiedCount(this string source)
        {
            return source.Length - (GetAlphabeticCount(source) + GetDigitalCount(source));
        }

        public static string GetTotalCounts(this string source)
        {
            return $"Source string: \"{source}\"\n" +
                $"Count of alphabetical symbols: {source.GetAlphabeticCount()}\n" +
                $"Count of digital symbols: {source.GetDigitalCount()}\n" +
                $"Count of special symbols: {source.GetSpecifiedCount()}\n" +
                $"Total count of symbols: {source.Length}\n";
        }

        public static string Sort(this string source)
        {
            var charArray = source.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        public static char[] Duplicate(this string source)
        {
            var chars = source.ToCharArray().Distinct();
            return chars.Where(c => source.Count(s => s.Equals(c)) > 1).ToArray();
        }
    }
}
