using System;

namespace ФоноваяМассивы
{
    class Program

    {
        static int IndexOfFirstMax(int[] array) //works
        {
            int max = int.MinValue, index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
                
            }
            return index;
        }
        static int IndexOfLastMin(int[] array) //w
        {
            int min = int.MaxValue, index = 0;
            for(int i = array.Length-1; i > 0; i--)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }
        static int[] Cin(int N) //w
        {
            int[] array = new int[N];
            for(int i = 0; i < N; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static void Cout(int[] array) //w
        {
            foreach (int i in array)
                Console.Write(i + " ");
        }

        static int ElementsBetweenMinAndMax(int[] array) // works
        {
            int min = IndexOfLastMin(array), max = IndexOfFirstMax(array), sum = 0;
            if (min > max)
            {
                for (int i = max + 1; i < min; i++)
                {
                    sum += array[i];
                }
            }
            else
            {
                for (int i = min + 1; i < max; i++)
                {
                    sum += array[i];
                }
            }
            return sum;
        }

        static void ElementsShift(int[] array, int k) //поменять на int[]? TODO доделать
        {
            int temp = 0;
            while(k > 0)
            {
                   temp = array[0];
                   for(int i = 1; i < array.Length; i++)
                {
                    array[i - 1] = array[i];
                    array[^1] = temp;
                    
                }
                k--;
            }
            Cout(array);
        }


        static void Intersection(int[] array, int[] array2) //TODO исправить
        {   int swap = 0, swapPrevious = 0; //буфер
            for(int i = 0; i < array.Length-1; i++)
            {
                for(int j = 0; j < array2.Length-1; j++)
                {
                    if (array2[j] == array[i]) swap = array2[j];
                }
                if (swapPrevious != swap)
                {
                    Console.Write(swap + " ");
                }
                swapPrevious = swap;
                swap = 0; //его сброс
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для 1 массива:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 1 массив:");
            int[] array = Cin(N);
            Console.WriteLine("Введите число для 2 массива:");
             int N2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 массив:");
            int[] array2 = Cin(N2);
            Console.WriteLine("Введите число для сдвига 1го массива:");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Массив 1: ");
            Cout(array);
            Console.WriteLine("\n"+"Массив 2: ");
            Cout(array2);
            Console.WriteLine("\n" + "Сумма элементов, расположенных между первым максимальным и последним минимальными элементами:" + ElementsBetweenMinAndMax(array));
            Console.WriteLine("Массив со сдвигом на k: ");
            ElementsShift(array, k);
            Console.WriteLine("\n"+"Пересечение 2х массивов: ");
            Intersection(array, array2);
        }
    }
}
