using System;
using System.Globalization;

public class Person
{
    // Автоматические свойства
    public string LastName { get; }
    public string FirstName { get; }
    public string MiddleName { get; }
    public float Weight { get; }
    public DateTime BirthDate { get; }

    // Приватное поле и публичное свойство для пола
    private bool gender;
    public bool Gender => gender;

    // Вычисляемое свойство для возраста
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }
    }

    // Конструктор
    public Person(string firstName, string lastName, string middleName, bool gender, float weight, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        this.gender = gender;
        Weight = weight;
        BirthDate = birthDate;
    }

    // Метод для разбора строки и создания объекта Person
    public static Person Parse(string text)
    {
        var parts = text.Split(',');
        if (parts.Length != 6)
            throw new FormatException("Неверный формат данных");

        var firstName = parts[0].Trim();
        var lastName = parts[1].Trim();
        var middleName = parts[2].Trim();
        var gender = parts[3].Trim().ToLower() == "мужской";
        var weight = float.Parse(parts[4].Trim(), CultureInfo.InvariantCulture);
        var birthDate = DateTime.Parse(parts[5].Trim(), new CultureInfo("ru-RU"));

        return new Person(firstName, lastName, middleName, gender, weight, birthDate);
    }

    // Метод для преобразования объекта Person в строку
    public override string ToString()
    {
        return $"{FirstName} {LastName} {MiddleName}, Пол: {(Gender ? "Мужской" : "Женский")}, Вес: {Weight:F2}, Дата рождения: {BirthDate:dd MMM yyyy}, Возраст: {Age}";
    }
}
