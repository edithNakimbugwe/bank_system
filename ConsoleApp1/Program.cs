using System;

class BankSystem
{
    // Variables to store user details
    static string userName = string.Empty;
    static string password = string.Empty;
    static decimal balance = 0;

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
    
    //Register
    static void Register()
    {
        Console.Write("Enter your name: ");
        userName = Console.ReadLine();

        Console.Write("Set your password: ");
        password = Console.ReadLine();

        Console.WriteLine($"Registration successful! Welcome, {userName}.");
    }

    // login
    static bool Login()
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("No user registered yet. Please register first.");
            return false;
        }

        Console.Write("Enter your name: ");
        string inputName = Console.ReadLine();

        Console.Write("Enter your password: ");
        string inputPassword = Console.ReadLine();

        if (inputName == userName && inputPassword == password)
        {
            Console.WriteLine($"Login successful! Welcome back, {userName}.");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid credentials. Please try again.");
            return false;
        }
    }

    // bank operations
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
                    Console.WriteLine($"Your current balance is: {balance:C}");
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

    // deposit money
    static void DepositMoney()
    {
        Console.Write("Enter the amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposit successful! Your new balance is: {balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
    }

    // withdraw money
    static void WithdrawMoney()
    {
        Console.Write("Enter the amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawal successful! Your new balance is: {balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
    }
}
