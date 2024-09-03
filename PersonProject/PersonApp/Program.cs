using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Запрос к пользователю для выбора типа данных
        Console.WriteLine("Выберите тип данных для обработки:");
        Console.WriteLine("1 - Person (класс)");
        Console.WriteLine("2 - PersonRecord (запись)");
        var choice = Console.ReadLine();

        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Некорректный выбор. Завершение программы.");
            return;
        }

        // Путь к файлам
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        if (choice == "1")
        {
            // Обработка с использованием класса Person
            List<Person> people = new List<Person>();

            foreach (var line in File.ReadLines(inputFilePath))
            {
                try
                {
                    Person person = Person.Parse(line);
                    people.Add(person);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Ошибка при разборе строки: {e.Message}");
                }
            }

            Console.WriteLine("Выберите способ сортировки (1 - по возрастанию, 2 - по убыванию):");
            var sortOption = Console.ReadLine();
            bool ascending = sortOption == "1";

            if (ascending)
            {
                people = people.OrderBy(p => p.BirthDate).ToList();
            }
            else
            {
                people = people.OrderByDescending(p => p.BirthDate).ToList();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var person in people)
                {
                    writer.WriteLine(person.ToString());
                }
            }
        }
        else if (choice == "2")
        {
            // Обработка с использованием записи PersonRecord
            List<PersonRecord> people = new List<PersonRecord>();

            foreach (var line in File.ReadLines(inputFilePath))
            {
                try
                {
                    PersonRecord person = PersonRecord.Parse(line);
                    people.Add(person);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Ошибка при разборе строки: {e.Message}");
                }
            }

            Console.WriteLine("Выберите способ сортировки (1 - по возрастанию, 2 - по убыванию):");
            var sortOption = Console.ReadLine();
            bool ascending = sortOption == "1";

            if (ascending)
            {
                people = people.OrderBy(p => p.BirthDate).ToList();
            }
            else
            {
                people = people.OrderByDescending(p => p.BirthDate).ToList();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var person in people)
                {
                    writer.WriteLine(person.ToString());
                }
            }
        }

        Console.WriteLine("Сортировка выполнена. Результаты записаны в файл output.txt.");
    }
}
