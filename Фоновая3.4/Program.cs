using System;

namespace Фоновая3._4
{
    class Program

    {
        static int[][] InputArray()
        {
            Console.Write("Введите количество строк: ");
            int stroka = int.Parse(Console.ReadLine()); int[][] ar;
            ar = new int[stroka][];
            string[] s;
            for(int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine("Введите кол-во элементов в {0} строке", i+1);
                ar[i] = new int[int.Parse(Console.ReadLine())]; 
             
                    Console.Write("Введите элементы через пробел: ");
                    s = Console.ReadLine().Split(new char[] { ' ' });
                int j = 0;
                foreach (string index in s)
                {
                    ar[i][j] = int.Parse(index);
                    j++;
                }
            }
            return ar;
        }

        static void Cout(int[][] ar)
        {
            foreach (int[] i in ar)
            {
                foreach (int j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }
        static void SummaVStolbcach(int[][] ar)
        {
            int sum = 0;
            int max = int.MinValue;
            
            foreach (int[] i in ar)
            {
                if (i.Length > max)
                    max = i.Length;
            }


            int[] arOfSum = new int[max];
            int k = 0;


            for(int i = 0; i < max; ++i)
            {
                foreach(int[] array in ar)
                {
                    if (k > array.Length - 1)
                        sum += 0;
                    else
                        sum += array[k];
                    
                }
                arOfSum[i] = sum;
                sum = 0;
                k++;
            }


            Console.Write("\n" + "Массив из сумм элементов в столбцах: ");
            foreach (int i in arOfSum)
                Console.Write(i + " ");
            
        }
        static void Minus(int[][] ar)
        {
            
            int k = 0;
            foreach(int[] i in ar)
            {
                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j] < 0)
                    {
                        k++;
                    }
                }
            }
            if (k == 0)
            {
                throw new Exception("В ГЛАВНОМ МАССИВЕ НЕТ ОТРИЦАТЕЛЬНЫХ ЭЛЕМЕНТОВ!!!");
            }
            if(k == 1)
            {
                throw new Exception("в массиве только 1 элемент");
            }
            int[] arr = new int[k];
            k = 0;
            foreach(int[] i in ar)
            {
                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j] < 0)
                    {
                        arr[k] = i[j];
                        k++;
                    }
                }
            }
            Array.Sort(arr);
            Console.WriteLine();
            foreach (int i in arr)
                Console.Write("{0} ", i);
        }
        static void Main(string[] args)
        {
            int[][] ar = InputArray();
            Cout(ar);
            SummaVStolbcach(ar);
            Minus(ar);
        }
    }
}
