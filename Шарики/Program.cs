using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Program
    {
        
        static bool GameOver(ref string [,] field , ref int points)
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
                Console.WriteLine("Ваши очки: {0}", points);
                Console.ResetColor();
                return false;
            }
            return true;
            
        }

        
        static (string[,], ConsoleColor[,]) Filling(ref string[,] field, ref int n, ref ConsoleColor[,] color)
        {
            
            Random rand = new Random();
            int x = rand.Next(0, 10);
            int y = rand.Next(0, 10);
            for (int i = 0; i < n; i++)
            {
                while (field[y, x] == char.ConvertFromUtf32(9679))
                {
                    x = rand.Next(0, 10);
                    y = rand.Next(0, 10);
                }
                field[y, x] = char.ConvertFromUtf32(9679);
                color[y, x] = CircleColor();
            }
            return (field, color);
        }
        static (string[,], ConsoleColor[,]) Move(ref string[,] field, int x, int y, ref ConsoleColor[,] colorArray, int x1, int y1)
        {
            int x2 = x, y2 = y; string ball = char.ConvertFromUtf32(9679);
            while(field[y2,x2] != field[y1, x1])
            {
                if(field[y2--,x2] != ball && y2<=10)
                {
                    y2--;
                }
                else
                {
                    if(field[y2,x2--] != ball && x2 <= 10)
                    {
                        x2--;
                        if (field[y2--, x2] != ball && y2 <= 10)
                        {
                            y2--;
                        }
                        else
                        {
                            if (field[y2, x2--] != ball && x2 <= 10)
                            {
                                x2--;

                            }
                            else
                            {
                                if (field[y2, x2++] != ball && x2 <= 10)
                                {
                                    x2++;
                                }
                                else
                                {
                                    if (field[y2++, x2] != ball && y2 <= 10)
                                    {
                                        y2++;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if(field[y2,x2++] != ball && x2 <= 10)
                        {
                            x2++;
                            if (field[y2--, x2] != ball && y2 <= 10)
                            {
                                y2--;
                            }
                            else
                            {
                                if (field[y2, x2--] != ball && x2 <= 10)
                                {
                                    x2--;

                                }
                                else
                                {
                                    if (field[y2, x2++] != ball && x2 <= 10)
                                    {
                                        x2++;
                                    }
                                    else
                                    {
                                        if (field[y2++, x2] != ball && y2 <= 10)
                                        {
                                            y2++;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if(field[y2++,x2] != ball && y2 <= 10)
                            {
                                y2++;
                                if (field[y2--, x2] != ball && y2 <= 10)
                                {
                                    y2--;
                                }
                                else
                                {
                                    if (field[y2, x2--] != ball && x2 <= 10)
                                    {
                                        x2--;

                                    }
                                    else
                                    {
                                        if (field[y2, x2++] != ball && x2 <= 10)
                                        {
                                            x2++;
                                        }
                                        else
                                        {
                                            if (field[y2++, x2] != ball && y2 <= 10)
                                            {
                                                y2++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                field[y, x] = "";
                field[y1, x1] = ball;
                colorArray[y1, x1] = colorArray[y, x];
                colorArray[y, x] = ConsoleColor.Black;
                return (field, colorArray);
        }
        static ConsoleColor CircleColor()
        {
            Random rand = new Random();
            ConsoleColor[] Colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int index = rand.Next(Colors.Length);
            return Colors[index];
        }

        static void Cout(ref string[,] array, ref ConsoleColor[,] color)
        {   Console.Write("   ");
            for(int i = 0; i < 10; i++)
            {
                Console.ResetColor();
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            for(int i = 0; i < 10; i++)
            {
                Console.ResetColor();
                Console.Write(" {0} ", i);
                for(int j = 0; j < 10; j++)
                {
                    if (array[i, j] == Char.ConvertFromUtf32(9679))
                    {
                        Console.ForegroundColor = color[i, j];
                        Console.Write(" {0} ", array[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
                
            }
            
        }

        static (int, string[,], ConsoleColor[,]) Line(ref string[,] Field, ref ConsoleColor[,] colors, ref int points)
        {
           
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                   if(Field[i,j] == char.ConvertFromUtf32(9679) && colors[i,j] == colors[i, j + 1] && colors[i,j] == colors[i,j+2])
                    {
                        
                        
                            Field[i, j] = "";
                        Field[i, j + 1] = "";
                        Field[i, j + 2] = "";
                        colors[i, j] = ConsoleColor.Black;
                        colors[i, j + 1] = ConsoleColor.Black;
                        colors[i, j + 2] = ConsoleColor.Black;
                        points+=10;
                        
                    }
                    
                }
            }
            for (int i = 2; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(Field[i,j] == char.ConvertFromUtf32(9679) && colors[i,j] == colors[i-1,j+1] && colors[i,j] == colors[i - 2, j + 2])
                    {
                        
                       
                            Field[i, j] = "";
                        Field[i -1, j + 1] = "";
                        Field[i - 2, j + 2] = "";
                        colors[i , j] = ConsoleColor.Black;
                        colors[i - 1, j + 1] = ConsoleColor.Black;
                        colors[i - 2, j + 2] = ConsoleColor.Black;
                        points+=10;
                        
                    }
                }
            }
            for (int i = 2; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(Field[i,j] == char.ConvertFromUtf32(9679) && colors[i,j] == colors[i+1,j] && colors[i,j] == colors[i + 2, j])
                    {
                        
                       
                       
                            Field[i, j] = "";
                        Field[i + 1, j] = "";
                        Field[i + 2, j] = "";
                        colors[i, j] = ConsoleColor.Black;
                        colors[i + 1, j] = ConsoleColor.Black;
                        colors[i + 2, j] = ConsoleColor.Black;
                        points+=10;
                        
                    }
                }
            }
                    return (points, Field, colors);
        
            }
            static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
"\n ╔╗──╔══╗╔╗─╔╗╔═══╗╔══╗" +
"\n ║║──╚╗╔╝║╚═╝║║╔══╝║╔═╝" +
"\n ║║───║║─║╔╗─║║╚══╗║╚═╗" +
"\n ║║───║║─║║╚╗║║╔══╝╚═╗║" +
"\n ║╚═╗╔╝╚╗║║─║║║╚══╗╔═╝║" +
"\n ╚══╝╚══╝╚╝─╚╝╚═══╝╚══╝");
            Console.ResetColor();
            Console.WriteLine("\n \n Добро пожаловать в игру Lines! " +
            "Цель игры - набить как можно больше очков, создавая линии от 3х шаров одинакового цвета по вертикали, горизонтали и вертикали. " +
            "За каждую линию начисляется 10 очков. " +
            "После каждого хода генерируется столько шариков, сколько вы сейчас введёте");
        }

       
        static void Main(string[] args)
        {
            int x, y, x1, y1, points = 0;
            Welcome();
            ConsoleColor[,] colorArray = new ConsoleColor[10,10];
            string[,] Field = new string[10,10];
            Console.WriteLine("Очки: {0}", points);
            Console.Write("Введите кол-во стартовых шаров: ");
            int startBalls = int.Parse(Console.ReadLine());
            
            Filling(ref Field, ref startBalls, ref colorArray);

            Cout(ref Field, ref colorArray);
            Console.ResetColor();
           
            while (GameOver(ref Field, ref points) == true)
            {
                    
                    Console.Write("Введите координаты шара (X;Y):");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    Console.Write("Введите место (X;Y):");
                    x1 = int.Parse(Console.ReadLine());
                    y1 = int.Parse(Console.ReadLine());

                    while(Field[y,x] != char.ConvertFromUtf32(9679))
                {
                    
                    Console.Write("\r Координаты шара введены неверно! Повторите ввод (X;Y): ");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                }
                while (Field[y1, x1] == char.ConvertFromUtf32(9679))
                {
                    
                    Console.Write("\r Координаты места введены неверно! Повторите ввод (X;Y):");
                    x1 = int.Parse(Console.ReadLine());
                    y1 = int.Parse(Console.ReadLine());
                }
                    
                    Move(ref Field, x, y, ref colorArray, x1, y1);
                    Console.ResetColor();

                    Line(ref Field, ref colorArray, ref points);
                
                Console.ResetColor();
                    Console.Clear();

                    Console.WriteLine("Очки: {0}", points);
                    Cout(ref Field, ref colorArray);
                    Filling(ref Field, ref startBalls, ref colorArray);
                    Line(ref Field, ref colorArray, ref points);
                
                Console.Clear();
                    Console.ResetColor();

                    Console.WriteLine("Очки: {0}", points);
                    Cout(ref Field, ref colorArray);
                    Console.ResetColor();
            }
            Console.ReadKey();
        }
    }
}
