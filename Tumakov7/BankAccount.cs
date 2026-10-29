using BankSystem;

public class BankAccount
{
	// Упр 7.2: Статическая переменная для генерации уникального номера
	private static ulong _lastAccountNumber = 10000000000000000000UL;

	// Упр 7.1: Закрытые поля (Инкапсуляция)
	private string? _accountNumber;
	private decimal _balance;
	private AccountType _accountType;

	// Упр 7.2: Статический метод, увеличивающий значение статической переменной
	private static string GenerateUniqueNumber()
	{
		_lastAccountNumber++;
		return _lastAccountNumber.ToString();
	}

	/// <summary>
	/// Метод заполнения данных вручную (для Упражнения 7.1)
	/// </summary>
	public void SetAccountDataManual(string number, decimal initialBalance, AccountType type)
	{
		if (initialBalance < 0) throw new ArgumentException("Баланс не может быть отрицательным.");
		_accountNumber = number;
		_balance = initialBalance;
		_accountType = type;
	}

	/// <summary>
	/// Метод заполнения данных автоматически (для Упражнений 7.2 и 7.3)
	/// </summary>
	public void SetAccountDataAuto(decimal initialBalance, AccountType type)
	{
		if (initialBalance < 0) throw new ArgumentException("Баланс не может быть отрицательным.");
		_accountNumber = GenerateUniqueNumber();
		_balance = initialBalance;
		_accountType = type;
	}

	// Упр 7.1: Методы чтения данных (Getters)
	public string? GetAccountNumber() => _accountNumber;
	public decimal GetBalance() => _balance;
	public AccountType GetAccountType() => _accountType;

	// Упр 7.3: Метод положить на счет
	public void Deposit(decimal amount)
	{
		if (amount <= 0) return;
		_balance += amount;
		Console.WriteLine($"[Пополнение] На счет {_accountNumber} зачислено: +{amount:N2} руб.");
	}

	// Упр 7.3: Метод Снять со счета с проверкой остатка
	public bool Withdraw(decimal amount)
	{
		if (amount <= 0) return false;

		if (_balance >= amount)
		{
			_balance -= amount;
			Console.WriteLine($"[Снятие] Со счета {_accountNumber} успешно снято: -{amount:N2} руб.");
			return true;
		}

		Console.WriteLine($"[Отказ] На заданном счете недостаточно средств для снятия {amount:N2} руб.!");
		return false;
	}

	// Упр 7.1: Метод вывода информации на печать
	public void PrintInfo()
	{
		Console.WriteLine($"Номер счета: {_accountNumber ?? "Не указан"}");
		Console.WriteLine($"Тип счета:   {_accountType}");
		Console.WriteLine($"Баланс:      {_balance:N2} руб.");
	}
}