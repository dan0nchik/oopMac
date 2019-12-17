using System;

namespace Фоновая4вар
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = {1, 4, 3, 8, 3, 3, 9, 12};
            int i = 0;
            while (mas[i] % 2 != 0)
                i++;

            Console.WriteLine(mas[i]);



            int n = 8;
            int k = n - 1;
            while (mas[k] % 3 == 0)
                k--;

            Console.WriteLine(mas[k]);
        }
    }
}
