using System;
using System.Globalization;

public record PersonRecord(
    string FirstName,
    string LastName,
    string MiddleName,
    bool Gender,
    float Weight,
    DateTime BirthDate)
{
    // Вычисляемое свойство для возраста
    public int Age => DateTime.Today.Year - BirthDate.Year - (DateTime.Today < BirthDate.AddYears(DateTime.Today.Year - BirthDate.Year) ? 1 : 0);

    // Метод для разбора строки и создания объекта PersonRecord
    public static PersonRecord Parse(string text)
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

        return new PersonRecord(firstName, lastName, middleName, gender, weight, birthDate);
    }

    // Метод для преобразования объекта PersonRecord в строку
    public override string ToString()
    {
        return $"{FirstName} {LastName} {MiddleName}, Пол: {(Gender ? "Мужской" : "Женский")}, Вес: {Weight:F2}, Дата рождения: {BirthDate:dd MMM yyyy}, Возраст: {Age}";
    }
}
