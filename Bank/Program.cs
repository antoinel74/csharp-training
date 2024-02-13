using System;
using Microsoft.Win32.SafeHandles;

namespace BankProgram {
    public class Client {
        public int Id {get;}
        public string Name {get;}
        public DateTime DateJoined {get;}
        public Client(int id,string name,DateTime dateJoined) {
            Id = id;
            Name = name;
            DateJoined = dateJoined;
        }
    }
    
    public class BankAccount {
        private Client client;
        private double balance;
        private string type;
        public BankAccount(Client client, double initialBalance, string accountType) 
        {
            this.client = client;
            balance = initialBalance;
            type = accountType;
        }

         public double CheckBalance()
        {
            return balance;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0) {
                Console.WriteLine("Invalid amount for withdrawal");
                return;
            }
            if (amount > balance ) {
                Console.WriteLine("Not enough funds.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"You withdraw {amount} successfully. Current balance : {balance}€");
        }

        public void Deposit(double amount) 
        {
            if (amount <= 0) {
                Console.WriteLine("Invalid amount for deposit");
                return;
            }
            balance += amount;
            Console.WriteLine($"You add {amount} successfully. Current balance : {balance}€");
        }
    }

    class Program {
        static void Main(string[] args)
        {
            string usr = "antoine";
            string pswrd = "1111";

            Console.WriteLine("Welcome to SpyBank");
            Console.Write("Please enter your username :");
            string enteredUsername = Console.ReadLine()!;

           Console.Write("Enter password :");
           string enteredPswrd = Console.ReadLine()!;

           if (enteredUsername == usr && enteredPswrd == pswrd)
           {
                Client client = new Client(1, usr, DateTime.Now);
                BankAccount bankAccount = new BankAccount(client, 1000, "Standard");

                // USER DASHBOARD  
                Console.WriteLine($"Welcome, {client.Name}!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.Write("Enter your choice (1, 2, or 3): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Current balance : {bankAccount.CheckBalance()}");
                        break;
                    case "2":
                        Console.Write("Enter the amount you want to withdraw: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        bankAccount.Withdraw(amount);
                        Console.WriteLine($"Succes. Current balance: {bankAccount.CheckBalance()}");
                        break;
                    case "3":
                        Console.Write("Enter the amount you want to deposit: ");
                        double deposit = Convert.ToDouble(Console.ReadLine());
                        bankAccount.Deposit(deposit);
                        Console.WriteLine($"Succes. Current balance: {bankAccount.CheckBalance()}");
                        break;
                    default:
                        Console.WriteLine("Invalid. Type 1, 2 or 3.");
                        break;
                }
           }
           Console.WriteLine("Invalid username or password. Access denied.");
        }
    }
}