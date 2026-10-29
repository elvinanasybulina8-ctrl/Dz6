using BankSystem;

class Program
{
    static void Main(string[] args)
    {

        Task71();
        Task72();
        Task73();

        Console.WriteLine("\nВсе задания успешно выполнены. Нажмите клавишу для выхода...");
        Console.ReadKey();
    }

    /// <summary>
    /// Упражнение 7.1: Ручной ввод номера счета и вывод на печать
    /// </summary>
    static void Task71()
    {
        Console.WriteLine("Упражнение 7.1 (Ручной ввод данных)");

        // Демонстрация переменной перечисления из упр 3.1
        AccountType testEnum = AccountType.Tekushchiy;
        Console.WriteLine($"Упр 3.1 Тестовый вывод переменной перечисления: {testEnum}");

        BankAccount account = new BankAccount();
        // Заполняем номер счета вручную, как требует условие 7.1
        account.SetAccountDataManual("40817810000001234567", 85000.50m, AccountType.Sberegatelny);
        account.PrintInfo();

        // Чтение отдельного поля через метод чтения
        Console.WriteLine($"Проверка баланса через Getter: {account.GetBalance():N2} руб.");
    }

    /// <summary>
    /// Упражнение 7.2: Автоматическая генерация уникального номера через static-переменную
    /// </summary>
    static void Task72()
    {
        Console.WriteLine(" Упражнение 7.2 (Автоматический уникальный номер)");

        BankAccount acc1 = new BankAccount();
        acc1.SetAccountDataAuto(15000.00m, AccountType.Tekushchiy);
        acc1.PrintInfo();

        BankAccount acc2 = new BankAccount();
        acc2.SetAccountDataAuto(500000.00m, AccountType.Sberegatelny);
        acc2.PrintInfo();
    }

    /// <summary>
    /// Упражнение 7.3: Добавление методов пополнения (Deposit) и снятия (Withdraw)
    /// </summary>
    static void Task73()
    {
        Console.WriteLine(" Упражнение 7.3 (Пополнение и снятие с проверкой)");

        BankAccount myAccount = new BankAccount();
        myAccount.SetAccountDataAuto(30000.00m, AccountType.Sberegatelny);
        myAccount.PrintInfo();

        // Тестируем операцию пополнения баланса
        myAccount.Deposit(12500.25m);
        Console.WriteLine($"Текущий баланс: {myAccount.GetBalance():N2} руб.\n");

        // Тестируем операцию успешного снятия денег
        myAccount.Withdraw(15000.00m);
        Console.WriteLine($"Текущий баланс: {myAccount.GetBalance():N2} руб.\n");

        // Тестируем логику отказа (снятие суммы больше, чем есть на балансе)
        myAccount.Withdraw(100000.00m);

        // Итоговый вывод состояния объекта
        myAccount.PrintInfo();
    }
}