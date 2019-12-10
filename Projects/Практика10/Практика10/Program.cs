using System;
using System.Diagnostics;
namespace Практика9
{
    class Program
    {
        static int NumberOfLetters(string a)
        {
            int length = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i])) length++;
            }
            return length;
        }
        static string BetweenBrackets(string a)
        {
            int leftBracket = a.IndexOf('(');
            int rightBracket = a.IndexOf(')');
            return a.Remove(leftBracket, rightBracket - leftBracket + 1);
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Console.WriteLine("Количество букв: {0}", NumberOfLetters(a));
            Console.WriteLine("Новая строка: {0}", BetweenBrackets(a));
        }
    }
}
