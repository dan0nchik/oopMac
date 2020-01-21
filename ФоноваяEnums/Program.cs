using System;

namespace ФоноваяEnums
{
    class Program
    {
        enum WeekDays
        {
            Понедельник = 1,
            Вторник,
            Среда,
            Четверг,
            Пятница,
            Суббота,
            Воскресенье
        }
        static int DayInNDays(int day, int amountOfDays)
        {
            int result = day-1;
            while(amountOfDays >= 0)
            {
                result++;
                amountOfDays--;
            }
            while (result > 7)
                result -= 7;
            return result;
        }
        static void Main(string[] args)
        {
            foreach(WeekDays day in Enum.GetValues(typeof(WeekDays))){
                Console.WriteLine("День недели: {0}, соответствует числу {1}", day, (int)day);
            }
            Console.Write("\n"+"Введите номер дня недели: ");
            int numOfDay = int.Parse(Console.ReadLine());
            Console.Write("\n"+"Введите количество дней: ");
            int amountOfDays = int.Parse(Console.ReadLine());
            Console.WriteLine("Через введенное кол-во дней наступит {0}, {1} день недели", (WeekDays)DayInNDays(numOfDay, amountOfDays), DayInNDays(numOfDay, amountOfDays));

        }
    }
}
