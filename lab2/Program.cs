namespace lab2;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        
        Console.WriteLine("1) тесты для PermissionPair");
        Console.WriteLine("2) тесты для AdvancedPermission");
        Console.WriteLine("3) тесты для Money");
        Console.Write("\nВыберите желаемый тест: ");

        var input = Console.ReadLine();
        Console.WriteLine(); // просто для отступа
        if (int.TryParse(input, out var choice))
        {
            switch (choice)
            {
                case 1: p.PermissionPairTests(); break;
                case 2: p.AdvancedPermissionTests(); break;
                case 3: p.MoneyTests(); break;
                default: Console.WriteLine("Такого варианта нет"); break;
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введено некорректное значение.");
        }
    }

    private void PermissionPairTests()
    {
        // Тест базового класса PermissionPair
        var pair1 = new PermissionPair();
        Console.WriteLine("Пустой конструктор PermissionPair:\n" + pair1 + "\n");

        var pair2 = new PermissionPair(true, false);
        Console.WriteLine("Конструктор с параметрами PermissionPair:\n" + pair2 + "\n");

        var pair3 = new PermissionPair(pair2);
        Console.WriteLine("Конструктор копирования PermissionPair:\n" + pair3 + "\n");
    }

    private void AdvancedPermissionTests()
    {
        // Тест дочернего класса AdvancedPermission
        var advanced1 = new AdvancedPermission();
        Console.WriteLine("Пустой конструктор AdvancedPermission (advanced1):\n" + advanced1 + "\n");

        var advanced2 = new AdvancedPermission(true, true, true, true);
        Console.WriteLine("Конструктор с параметрами AdvancedPermission (advanced2):\n" + advanced2 + "\n");

        var advanced3 = new AdvancedPermission(advanced2);
        Console.WriteLine("Конструктор копирования AdvancedPermission (advanced3):\n" + advanced3 + "\n");

        // Тест методов дочернего класса
        Console.WriteLine("HasFullAccess для advanced2: " + advanced2.HasFullAccess());
        Console.WriteLine("HasLimitedAccess для advanced2: " + advanced2.HasLimitedAccess());
        Console.WriteLine("CanManageAll для advanced2: " + advanced2.CanManageAll());
    }
    
    private void MoneyTests()
    {
        // Тесты конструкторов
        var money1 = new Money();
        Console.WriteLine("Пустой конструктор Money: " + money1); // Ожидаем 0 рублей 0 копеек

        var money2 = new Money(10, 50);
        Console.WriteLine("Конструктор с параметрами (10 рублей, 50 копеек): " + money2); // Ожидаем 10 рублей 50 копеек

        var money3 = new Money(money2);
        Console.WriteLine("Конструктор копирования Money: " + money3); // Ожидаем 10 рублей 50 копеек

        // Тест метода Subtraction
        var money4 = new Money(5, 25);
        money4.Subtraction(50); // Вычитаем 50 копеек
        Console.WriteLine("Метод Subtraction (вычитание 50 копеек из 5 рублей и 25 копеек): " + money4); // Ожидаем 4 рубля 75 копеек

        try
        {
            money4.Subtraction(500); // Пытаемся вычесть больше, чем имеется
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Метод Subtraction (недостаточно средств для вычитания): " + e.Message); // Ожидаем ошибку
        }

        // Тест операторов инкремента и декремента
        var money5 = new Money(1, 99);
        money5++;
        Console.WriteLine("Оператор инкремента (++ для 1 рубля и 99 копеек): " + money5); // Ожидаем 2 рубля 0 копеек

        money5--;
        Console.WriteLine("Оператор декремента (-- для 2 рублей): " + money5); // Ожидаем 1 рубль 99 копеек

        // Тест явного преобразования к uint (только рубли)
        var rublesOnly = (uint)money5;
        Console.WriteLine("Явное преобразование к uint (только рубли для 1 рубля и 99 копеек): " + rublesOnly); // Ожидаем 1

        // Тест неявного преобразования к bool
        var money6 = new Money();
        Console.WriteLine("Неявное преобразование к bool (0 рублей, 0 копеек): " + (money6 ? "True" : "False")); // Ожидаем False

        var money7 = new Money(3, 15);
        Console.WriteLine("Неявное преобразование к bool (3 рубля, 15 копеек): " + (money7 ? "True" : "False")); // Ожидаем True

        // Тест оператора вычитания с байтом
        var money8 = new Money(2, 30);
        var result1 = money8 - (byte)50;
        Console.WriteLine("Оператор вычитания с byte (2 руб 30 коп - 50 копеек): " + result1); // Ожидаем 1 рубль 80 копеек

        // Тест оператора вычитания двух Money
        var money9 = new Money(10, 0);
        var money10 = new Money(3, 50);
        var result2 = money9 - money10;
        Console.WriteLine("Оператор вычитания двух Money (10 руб - 3 руб 50 коп): " + result2); // Ожидаем 6 рублей 50 копеек

        try
        {
            var result3 = money10 - money9; // Пытаемся вычесть больше, чем имеется
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Оператор вычитания двух Money (недостаточно средств): " + e.Message); // Ожидаем ошибку
        }
    }
}
