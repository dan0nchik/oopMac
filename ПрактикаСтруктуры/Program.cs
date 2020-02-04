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

            int counter = 1;
            if(enter.Contains("да"))
            {
                Console.Write("Введите число вакансий, которые вы хотите отправить в базу самостоятельно: ");
                int numOfVacancies = int.Parse(Console.ReadLine());
                for (int i = 2; i <= numOfVacancies; i++)
                {
                    Console.Write("Введите {0} профессию из {1}:",counter,numOfVacancies);
                    arOfData[i].Prof = Console.ReadLine();
                    Console.Write("Введите {0} компанию из {1}:", counter, numOfVacancies);
                    arOfData[i].Company = Console.ReadLine();
                    Console.Write("Введите {0} агенство из {1}:", counter, numOfVacancies);
                    arOfData[i].Agency = Console.ReadLine();
                    Console.Write("Введите {0} зарплату из {1}:", counter, numOfVacancies);
                    arOfData[i].Wage = int.Parse(Console.ReadLine());
                    counter++;
                }
            }
            return arOfData;
        }
        static void Cout(ref TVacansy[] arOfData, int indexOfVacancy)
        {
            Console.WriteLine($"Профессия: «{arOfData[indexOfVacancy].Prof}»");
            Console.WriteLine($"Компания работодатель: «{arOfData[indexOfVacancy].Company}»");
            Console.WriteLine($"Кадровое агенство: «{arOfData[indexOfVacancy].Agency}»");
            Console.WriteLine($"Заработная плата:  {arOfData[indexOfVacancy].Wage} руб.");
        }
        static void InputCheck(ref TVacansy[] arOfData, int wishWage, string wishedAgency)
        {
            bool foundAgency = false, wageIsHigh = false;
            for(int i = 0; i < arOfData.Length; i++)
            {
                if (wishWage <= arOfData[i].Wage && wishedAgency == arOfData[i].Agency)
                {
                    Console.WriteLine("Успешно! Резюме отправлено в эту компанию:");
                    Cout(ref arOfData, i);
                    foundAgency = true;
                    wageIsHigh = false;
                }
            }
            if (foundAgency == false) Console.WriteLine("Вакансия из другого агентства");
            if(wageIsHigh == true) Console.WriteLine("Зарплата слишком низкая"); 
        }
        static void Main(string[] args)
        {
            TVacansy[] arOfData = new TVacansy[5];
            
            string enter;
            Console.Write("Хотите сами заполнить данные (от 1 до 3 вакансий!)? напишите да или нет: ");
            enter = Console.ReadLine();
            FillingData(ref arOfData, enter);
            Console.Write("Введите желаемую зарплату: ");
            int wishWage = int.Parse(Console.ReadLine());
            Console.Write("Введите кадровое агенство: ");
            string wishedAgency = Console.ReadLine();
            InputCheck(ref arOfData, wishWage, wishedAgency);
        }
    }
}