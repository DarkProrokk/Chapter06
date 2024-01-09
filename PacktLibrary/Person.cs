using static System.Console;

namespace Packt.Shared;

public class Person : object
{
    //поля
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();

    //методы
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born a {DateOfBirth:dddd}");
    }
    //создание статичного метода
    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}"
    };
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }
    //создание метода экземпляра
    public Person ProcreateWith(Person parthner)
    {
        return Procreate(this, parthner);
    }

    //реализация функционала при помощи операций
    public static Person operator *(Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }

    public static int Factorial(int number)
    {
        if (number <0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);

        int localFactorial(int localNumber)
        {
            if (localNumber < 1) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
    //поле делегата
    public EventHandler? Shout;

    // поле данных
    public int AngerLevel;

    //метод

    public void Poke()
    {
        AngerLevel++;

        if (AngerLevel >= 3)
        {
            //если что-то прослушивается...
            Shout?.Invoke(this, EventArgs.Empty);
        }
    }
}
