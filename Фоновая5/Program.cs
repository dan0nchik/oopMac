using System;
namespace Фоновая5
{

    class Figura
    {
        protected int x, y;

        protected Figura()
        {
            x = 0;
            y = 0;
        }
        protected Figura(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        protected int GetX => x;

        protected int GetY => y;

        protected void Show() => Console.WriteLine($"X: {x} \n Y: {y}");
    }

    class Triangle : Figura
    {
        private int a, b, beta;
        private new int x, y;

        public Triangle(int a, int b, int beta, int x, int y) : base(x, y)
        {
            try
            {
                if (a > 0 && b > 0 && beta > 1 && beta < 180)
                {
                    this.x = x;
                    this.y = y;
                    this.a = a;
                    this.b = b;
                    this.beta = beta;
                }
                else
                {
                    throw new Exception("ОШИБКА: какая-то из сторон или угол < 0, повторите еще раз");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public Triangle() : base()
        {
            x = GetX;
            y = GetY;
            a = 5;
            b = 7;
            beta = 50;
        }
        private double ToRadians() => (Math.PI / 180) * beta;

        public bool IsTriangle => a == b || b == GetC || a == GetC ? true : false;

        public double Area() => Math.Round(a * b * Math.Sin(ToRadians()) / 2, 2);

        public int GetA => a;

        public int GetB => b;

        public int SetA
        {
            set
            {
                if (value < 0) throw new Exception("Сторона А < 0!");
                else a = value;
            }
        }

        public int SetB
        {
            set
            {
                if (value < 0) throw new Exception("Сторона B < 0!");
                else b = value;
            }
        }

        public double GetC => Math.Round(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(ToRadians())), 2);


        public new void Show() => Console.WriteLine($" X: {x} \n Y: {y} \n a: {a} \n b: {b} \n c: {GetC} \n" +
            $" Угол: {beta} \n Площадь: {Area()} \n Р/бедренный?: {IsTriangle}");
    }

    class Rectangle : Figura
    {
        private int width, height;
        private new int x, y;

        public Rectangle(int width, int height, int x, int y) : base(x, y)
        {
            try
            {
                if (width > 0 && height > 0)
                {
                    this.width = width;
                    this.height = height;
                    this.x = x;
                    this.y = y;
                }
                else
                {
                    throw new Exception("ОШИБКА: какая-то из сторон < 0, повторите еще раз");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public Rectangle() : base()
        {
            x = GetX;
            y = GetY;
            width = 4;
            height = 8;
        }

        public bool IsSquare => width == height ? true : false;

        public int Area() => width * height;

        public int GetHeight => height;

        public int GetWidth => width;

        public int SetW
        {
            set
            {
                if (value < 0) throw new Exception("Ширина < 0!");
                else width = value;
            }
        }

        public int SetH
        {
            set
            {
                if (value < 0) throw new Exception("Высота < 0!");
                else width = value;
            }
        }

        public new void Show() => Console.WriteLine($" X: {x}\n Y: {y}\n Высота: {height}" +
            $" \n Ширина: {width} \n Площадь: {Area()} \n Квадрат?: {IsSquare}");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tri;
            Rectangle rec;
            int figure, mode;
            Console.WriteLine("Выберите фигуру: 1 - треугольник, 2 - прямоугольник");
            figure = int.Parse(Console.ReadLine());
            Console.WriteLine("Режим: ваши данные - 1, по умолчанию - 2");
            mode = int.Parse(Console.ReadLine());
            if (figure == 1)
            {
                if (mode == 1)
                {
                    Console.WriteLine("Введите X: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите Y: ");
                    int y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите сторону a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите сторону b: ");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите угол бета: ");
                    int beta = int.Parse(Console.ReadLine());
                    tri = new Triangle(a: a, b: b, beta: beta, x: x, y: y);
                }
                else
                {
                    tri = new Triangle();
                }
                tri.Show();
            }
            if (figure == 2)
            {
                if (mode == 1)
                {
                    Console.WriteLine("Введите X: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите Y: ");
                    int y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите высоту: ");
                    int h = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ширину: ");
                    int w = int.Parse(Console.ReadLine());
                    rec = new Rectangle(width: w, height: h, x: x, y: y);
                }
                else
                {
                    rec = new Rectangle();
                }
                rec.Show();
            }

        }
    }
}
