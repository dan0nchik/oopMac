using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace ФоноваяСтруктуры
{
    public struct Liceist
    {
        public string Surname;
        public string State;
        public double GroupNumber;
        public double[] Marks;

    }
    class Program
    {

        static Liceist[] EnterDataFromConsole(ref Liceist[] liceists, string[] subjects, int liceistsFromFile)
        {
            Console.WriteLine("Сколько лицеистов вы хотите ввести?");
            int amount = int.Parse(Console.ReadLine());
            for (int i = liceistsFromFile; i < amount + liceistsFromFile; i++)
            {
                Console.Write("Введите фамилию ученика: ");
                liceists[i].Surname = Console.ReadLine();
                Console.Write("Введите номер группы: ");
                liceists[i].GroupNumber = double.Parse(Console.ReadLine());
                Console.Write("Введите направление: ");
                liceists[i].State = Console.ReadLine();
                liceists[i].Marks = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("Введите среднюю оценку ученика по {0}:", subjects[j]);
                    liceists[i].Marks[j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введено!");
            Thread.Sleep(2000);
            Console.Clear();
            return liceists;
        }
        static int Interface()
        {
            Console.WriteLine("База данных ЛИЦЕИСТ. Выход - 0" + "\n" + "Ввести в базу лицеистов с клавиатуры - 1" + "\n" + "Вывести фамилии и номера групп тех лицеистов, средний бал которых больше 4.0 - 2" + "\n" + "Вывод на экран всех студентов указанной группы - 3" + "\n" + "Вывод на экран всех лицеистов, имеющих  одинаковый балл по выбранному предмету - 4" + "\n" + "Перевод всей группы из одного класса в другой - 5" + "\n" + "Создать справку для лицеиста - 6");
            return 0;
        }
        static int BestResults(ref Liceist[] liceists)
        {
            double middle = 0;
            int i = 0;
            bool araThereAny = false;
            while (liceists[i].Surname != null)
            {
                foreach (double j in liceists[i].Marks)
                middle += j;
                if ((middle / 5) > 4.0)
                {
                    Console.WriteLine(liceists[i].Surname + " " + liceists[i].GroupNumber);
                    araThereAny = true;
                }
                middle = 0;
                i++;
            }
            if (araThereAny == false) Console.WriteLine("Таких учеников нет :(");
            Thread.Sleep(2000);
            Console.Clear();
            return 0;
        }
        static (Liceist[], int) ReadFromFile(ref Liceist[] liceists)
        {
            int index = 0;
            if (new FileInfo("DataFromFile.txt").Length == 0)
            {   //проверка файла на пустоту
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл пустой - заполните файл или введите данные в консоль!");
                Console.ResetColor();
                return (liceists,index);
            }
            var path = Environment.CurrentDirectory + "/" + "DataFromFile.txt"; //путь
            string[] lines = File.ReadAllLines(path); //массив из строк
            index = int.Parse(lines[0]); // количество учеников
            int line = 1;
            for (int i = 0; i < index; i++)
            {
                liceists[i].Surname = lines[line];
                line++;
                liceists[i].GroupNumber = double.Parse(lines[line]);
                line++;
                liceists[i].State = lines[line];
                line++;
                liceists[i].Marks = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    liceists[i].Marks[j] = double.Parse(lines[line]);
                    line++;
                }

            }
            return (liceists,index);
        }
        static int AllInChosenGroup(Liceist[] liceists)
        {
            Console.Write("Введите номер группы:");
            double group = double.Parse(Console.ReadLine()); int i = 0;
            while(liceists[i].Surname != null)
            {
                if (liceists[i].GroupNumber == group)
                    Console.Write(liceists[i].Surname + " ");
                i++;
            }
            Thread.Sleep(2000);
            Console.Clear();
            return 0;
        }
        static int MarksForSubject(Liceist[] liceists)
        {
            Console.Write("Выберите предмет: математика - 1, рус - 2, англ - 3, физика - 4, программирование - 5: ");
            int sub = int.Parse(Console.ReadLine()), i = 0, index = 0;
            Console.Write("Введите балл: ");
            int mark = int.Parse(Console.ReadLine());
            while(liceists[i].Surname != null)
            {
                if (liceists[i].Marks[sub] == mark)
                {
                    Console.Write(liceists[i].Surname + " ");
                    index = 1;
                }
                i++;
            }
            if (index == 0) Console.WriteLine("Таких нет");
            Thread.Sleep(1500);
            Console.Clear();
            return 0;
        }
        static Liceist[] Transfer(ref Liceist[] liceists) //TODO изменять файл
        {
            int i = 0;
            Console.Write("Введите номер группы, ИЗ которой вы хотите перевести учеников: ");
            double group = double.Parse(Console.ReadLine());
            Console.Write("Введите номер группы, В которую вы хотите перевести учеников: ");
            double transferGroup = double.Parse(Console.ReadLine());

            while (liceists[i].Surname != null)
            {
                if (liceists[i].GroupNumber.Equals(group))
                    liceists[i].GroupNumber = transferGroup;
                i++;
            }
            Console.WriteLine("Готово!");
            Thread.Sleep(1000);
            Console.Clear();
            return liceists;
        }
        static int Info(Liceist[] liceists)
        {
            Console.Write("Введите фамилию ученика: ");
            string surname = Console.ReadLine();
            Console.Write("Введите группу: ");
            double group = double.Parse(Console.ReadLine());
            Console.Write("Введите направление - программирование, арм или экономика: ");
            string state = Console.ReadLine();
            Console.Write("Введите год (например, 2005): ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(@$"
                Справка
Дана {surname} в том, что он(а) действительно
обучается в ГБОУ Лицей 1533 в {group} классе.
Дата окончания обучения 30 июня 20{year%100}. Направление - {state}");
            Thread.Sleep(10000);
            Console.Clear();
            return 0;
        }
        static void Main(string[] args)
        {
            Liceist[] liceists = new Liceist[1000];
            
            int input = 1;
            string[] subjects = new string[5] { "математике", "русскому", "английскому", "физике", "программированию" };
            int liceistsFromFile = ReadFromFile(ref liceists).Item2;
            while (input != 0)
            {
                Interface();
                input = int.Parse(Console.ReadLine());
                if (input == 1) EnterDataFromConsole(ref liceists, subjects, liceistsFromFile);
                if (input == 2) BestResults(ref liceists);
                if (input == 3) AllInChosenGroup(liceists);
                if (input == 4) MarksForSubject(liceists);
                if (input == 5) Transfer(ref liceists);
                if (input == 6) Info(liceists);
            }
        }
    }
}
