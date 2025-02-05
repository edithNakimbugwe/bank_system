using System;

abstract class BankAccount
{
    private string _userName;
    private string _password;
    private decimal _balance;

    public BankAccount(string userName, string password)
    {
        _userName = userName;
        _password = password;
        _balance = 0;
    }

    // Getter for UserName
    public string GetUserName()
    {
        return _userName;
    }

    // Getter for Password
    public string GetPassword()
    {
        return _password;
    }

    // Getter for Balance
    public decimal GetBalance()
    {
        return _balance;
    }

    // Setter for Balance
    protected void SetBalance(decimal amount)
    {
        _balance = amount;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Deposit successful! New balance: {_balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public abstract void Withdraw(decimal amount);

    // check balance
    public void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: {_balance:C}");
    }
}

class SavingsAccount : BankAccount
{
    private const decimal MinimumBalance = 50; 

    // Constructor
    public SavingsAccount(string userName, string password) : base(userName, password) { }

    public override void Withdraw(decimal amount)
    {
        if (amount > 0 && (GetBalance() - amount) >= MinimumBalance)
        {
            SetBalance(GetBalance() - amount);
            Console.WriteLine($"Withdrawal successful! New balance: {GetBalance():C}");
        }
        else
        {
            Console.WriteLine($"Withdrawal failed! You must maintain a minimum balance of {MinimumBalance:C}.");
        }
    }
}

class BankSystem
{
    private static SavingsAccount account;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our Bank System!");

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    if (Login())
                    {
                        BankOperations();
                    }
                    break;
                case "3":
                    Console.WriteLine("Thank you for using our bank system!");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    // Register a user
    static void Register()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Set your password: ");
        string pass = Console.ReadLine();

        account = new SavingsAccount(name, pass);
        Console.WriteLine($"Registration successful! Welcome, {account.GetUserName()}.");
    }

    // Login
    static bool Login()
    {
        if (account == null)
        {
            Console.WriteLine("No user registered yet. Please register first.");
            return false;
        }

        Console.Write("Enter your name: ");
        string inputName = Console.ReadLine();

        Console.Write("Enter your password: ");
        string inputPassword = Console.ReadLine();

        if (inputName == account.GetUserName() && inputPassword == account.GetPassword())
        {
            Console.WriteLine($"Login successful! Welcome back, {account.GetUserName()}.");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid credentials. Please try again.");
            return false;
        }
    }

    // menu
    static void BankOperations()
    {
        while (true)
        {
            Console.WriteLine("\nBank Operations:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Logout");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    account.CheckBalance();
                    break;
                case "2":
                    DepositMoney();
                    break;
                case "3":
                    WithdrawMoney();
                    break;
                case "4":
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    // Deposit
    static void DepositMoney()
    {
        Console.Write("Enter the amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    // Withdraw
    static void WithdrawMoney()
    {
        Console.Write("Enter the amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
}
