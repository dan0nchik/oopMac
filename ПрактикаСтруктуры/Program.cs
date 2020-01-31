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
        static TVacansy[] FillingData(ref TVacansy[] arOfData, string enter)
        {

            arOfData[0].Prof = "Программист";
            arOfData[0].Company = "Google";
            arOfData[0].Agency = "Rabota.ru";
            arOfData[0].Wage = 150000;

            arOfData[1].Prof = "Дизайнер";
            arOfData[1].Company = "Apple";
            arOfData[1].Agency = "Headhunter.com";
            arOfData[1].Wage = 100000;

            if(enter == "Да")
            {
                //заполнение юзером
            }

        }
        static void Cout(TVacansy data)
        {
            TVacansy[] dataArray = new TVacansy[3];

        }
        static void InputCheck(TVacansy data, int wishWage, string wishedAgency)
        {

            if (wishWage <= data.Wage && wishedAgency == data.Agency)
                Console.WriteLine("Резюме отправлено!");
            if (wishWage > data.Wage)
                Console.WriteLine("Зарплата слишком низкая");
            if (wishedAgency != data.Agency)
                Console.WriteLine("Вакансия из другого агентства");
        }
        static void Main(string[] args)
        {
            TVacansy[] arOfData = new TVacansy[5];

            string enter = "";
            Console.Write("Хотите сами заполнить данные (до 3 вакансий!) напишите Да или Нет: ");
            enter = Console.ReadLine();
            FillingData(ref arOfData, enter);
            Console.Write("Введите желаемую зарплату: ");
            int wishWage = int.Parse(Console.ReadLine());
            Console.Write("Введите кадровое агенство: ");
            string wishedAgency = Console.ReadLine();
            
            InputCheck(data, wishWage, wishedAgency);
            Cout(data);

        }
    }
}