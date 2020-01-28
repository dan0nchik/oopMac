using System;

namespace ПрактикаСтруктуры
{
    public struct TVacansy
    {
        public string Prof;
        public string Company;
        public string Agency;
        public int Wage;
    }
    class Program
    {
        static void FillingData(ref TVacansy data)
        {
            
            data.Prof = "Программист";
            data.Company = "Google";
            data.Agency = "Rabota.ru";
            data.Wage = 100000;
        }
        static void Cout(TVacansy data)
        {
            Console.WriteLine("Профессия: {0}", data.Prof);
            Console.WriteLine("Компания работодатель: {0}", data.Company);
            Console.WriteLine("Кадровое агенство: {0}", data.Agency);
            Console.WriteLine("Заработная плата: {0}", data.Wage);
        }
        static void InputCheck(TVacansy data, int wishWage, string wishedAgency)
        {
            
            if (wishWage <= data.Wage && wishedAgency == data.Agency)
                Console.WriteLine( "Резюме отправлено!");
            if (wishWage > data.Wage)
                       Console.WriteLine( "Зарплата слишком низкая");
            if(wishedAgency != data.Agency)
                Console.WriteLine("Вакансия из другого агентства");
        }
        static void Main(string[] args)
        {
            TVacansy data = new TVacansy();
            Console.Write("Введите желаемую зарплату: ");
            int wishWage = int.Parse(Console.ReadLine());
            Console.Write("Введите кадровое агенство: ");
            string wishedAgency = Console.ReadLine();
            FillingData(ref data);
            InputCheck(data, wishWage, wishedAgency);
            Cout(data);
            
        }
    }
}
