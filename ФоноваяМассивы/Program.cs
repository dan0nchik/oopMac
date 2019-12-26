using System;

namespace ФоноваяМассивы
{
    class Program

    {
        static int IndexOfFirstMax(int[] array) 
        {
            int max = int.MinValue, index = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
        static int IndexOfLastMin(int[] array) 
        {
            int min = int.MaxValue, index = 0;
            for(int i = 0; i < array.Length; ++i)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
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

        static void Cout(int[] array) 
        {
            foreach (int i in array)
                Console.Write(i + " ");
        }

        static int ElementsBetweenMinAndMax(int[] array)
        {
            int lastMin = IndexOfLastMin(array), firstMax = IndexOfFirstMax(array), sum = 0;
            if (firstMax > lastMin) 
            {
                for (int i = lastMin+1; i < firstMax; ++i)
                {
                    sum += array[i];
                }
            }
            else 
            {
                for (int i = firstMax + 1; i < lastMin; ++i)
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        
         static void ElementsShift(int[] array, int k)
        {
            int temp;
            while(k > 0) { 
                temp = array[^1];
                for (int j = array.Length - 1; j > 0; j--) array[j] = array[j - 1];
                array[0] = temp;
                k--;
            }
            Cout(array);
        }
        static int[] ChangeRepeated(int[] array) 
        {
        
        for(int i = 0; i < array.Length; ++i)   
                
            {
                if(array[i] != -1)
                for(int j = i+1; j < array.Length; ++j)
                {
                    if (array[j] == array[i]) array[j] = -1;
                }
               
            }
         
        return array;
            
        }

        static void Intersection(int[] array, int[] array2)
        {
            ChangeRepeated(array); 
            ChangeRepeated(array2);
            
            for (int i = 0; i < array.Length; ++i)
            {
                    if(array[i] != -1)
                    for (int j = 0; j < array2.Length; ++j)
                    {
                        if (array2[j] == array[i]) Console.Write(array2[j] + " ");
                    }
            }
            
        }
        static int[] Delete(int[] array)
        {
            int[] newArray = new int[array.Length];
            ChangeRepeated(array);
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] != -1) newArray[i] = array[i];
            }
            return newArray;
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
            Console.Write("\n" + "Массив 2: ");
            Cout(array2);
            Console.WriteLine("\n" + "Сумма элементов, расположенных между первым максимальным и последним минимальными элементами: " + ElementsBetweenMinAndMax(array));
            Console.Write("Массив со сдвигом на k: ");
            ElementsShift(array, k);
            Console.Write("\n" + "Пересечение 2х массивов: ");
            Intersection(array, array2);
            Console.Write("\n" + "Массив после уудаления повторов: "); Cout(Delete(array));
        }
    }
}
