using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//9679
namespace Lines
{
    class Program
    {
        static bool GameOver(string [,] field)
        {
            int i = 0;
            foreach (string ball in field)
                if (ball == Char.ConvertFromUtf32(9679))
                    i++;
            if(i == 100)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
            }
            return true;
            
        }
        
        static (int[] mx, int[] my) Zip(int n, ref int flag)
        {

            if (flag == 1)
                n *= 2;

                int[] mx = new int[n];
                int[] my = new int[n];
                
            Random R = new Random();
            int x = R.Next(0, 10);
            int y = R.Next(0, 10);
            mx[0] = x;
            my[0] = y;
            for(int i = 1; i < n; i++)
            {
                x = R.Next(0, 10);
                y = R.Next(0, 10);
                for(int j = 0, k = 0; j < i && k < i; j++, k++)
                {
                    if(mx[j] == x && my[k] == y && j == k)
                    {
                        do
                        {
                            x = R.Next(0, 10);
                            y = R.Next(0, 10);
                        } while (mx[j] == x && my[k] == y && j == k);
                    }
                }
                mx[i] = x;
                my[i] = y;
            }
            
            return (mx, my);
        }

        
        static ConsoleColor CircleColor()
        {
            Random rand = new Random();
            ConsoleColor[] Colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int index = rand.Next(Colors.Length);
            return Colors[index];
        }

        static void Cout(string[,] array)
        {
            for(int i =0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (array[j, i] == Char.ConvertFromUtf32(9679) && Console.ForegroundColor == ConsoleColor.White)
                    {
                        Console.ForegroundColor = CircleColor();
                        Console.Write(" " + array[j, i] + " ");
                    }
                    else
                    {   Console.ResetColor();
                        Console.Write(" . ");
                        
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int flag = 0;
            string[,] Field = new string[10,10];
            string balls = Char.ConvertFromUtf32(9679);
            Console.Write("Введите кол-во стартовых шаров: ");
            int startBalls = int.Parse(Console.ReadLine());
            
            Console.ReadKey();
        }
    }
}
