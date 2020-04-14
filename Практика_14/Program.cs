using System;
namespace Практика_14
{
    public class DemoPoint
    {

        public int x, y;
        public DemoPoint()
        {
            x = 0;
            y = 0;
        }
        public DemoPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void show()
        {
            Console.WriteLine($"Координата точки: ({x};{y})");
        }
    }

    public class DemoLine : DemoPoint
    {
        public int x1, y1;
        public DemoLine() : base()
        {
            x1 = 0;
            y1 = 0;
        }
        public DemoLine(int x, int y, int x1, int y1) : base(x, y)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        new public void show()
        {
            base.show();
            Console.WriteLine($"Координата 2 точки: ({x1};{y1})");
            double d = Math.Sqrt(Math.Pow((x1 - x),2) + Math.Pow((y1 - y), 2));
            Console.WriteLine("\nСоздан отрезок, схематично показана его длина: ");
            Console.WriteLine($"({x};{y})");
            while(d > 0)
            {
                Console.WriteLine("  |");
                d--;
            }
            Console.WriteLine($"({x1};{y1})");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            DemoLine point;
            Console.WriteLine("Режим: 1 - ваши точки, 2 - по умолчанию");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                int x, y, x1, y1;
                Console.WriteLine("Введите X 1 точки: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Y 1 точки: ");
                y = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите X 2 точки: ");
                x1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Y 2 точки: ");
                y1 = int.Parse(Console.ReadLine());
                point = new DemoLine(x, y, x1, y1);
            }
            else {point = new DemoLine();}
            point.show();
        }
    }
}