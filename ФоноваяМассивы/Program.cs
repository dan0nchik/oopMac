using System;

namespace ФоноваяМассивы
{
    class Program

    {
        static int IndexOfFirstMax(int[] array)
        {
            int i = array[0], max = 0;
            foreach (int element in array)
                if (element > i) { max = element; break;} //TODO найти его индекс
            return max;
        }
        static int IndexOfLastMin(int[] array)
        {
            int i = int.MaxValue, min = 0;
            foreach (int element in array)
                if (element < i) min = element; //TODO найти его индекс
            return min;
        }
        static int[] Cin(int N)
        {
            int[] array = new int[N];
            for(int i = 0; i < N; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Cin(N);
            Console.WriteLine("Hello World!");
        }
    }
}
