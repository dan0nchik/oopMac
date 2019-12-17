using System;
using System.Diagnostics;
namespace Практика9
{
    class Program
    {
        static int NumberOfLetters(string a)
        {
            int l = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i])) l++;
            }
            return l;
        }
        static void BetweenBrackets(ref string a)
        {
            int leftBracket = a.IndexOf('(');
            int rightBracket = a.IndexOf(')');
            a = a.Remove(leftBracket, rightBracket - leftBracket + 1);
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Console.WriteLine("Количество букв: {0}", NumberOfLetters(a));
            BetweenBrackets(ref a);
            Console.WriteLine(a);

        }
    }
}
