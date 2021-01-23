    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                
       
            }
            static void CreateNewAccount()
            {
                Bank bank = new Bank();
                Console.WriteLine("Enter a name for a new account.");
                string bname = Console.ReadLine();
                Console.WriteLine("Creating a new account for : {0}", bname);
                BankAccount account = new BankAccount(bname, 0);
                Console.WriteLine(bank.GetAccounts().Exists(x => x.name == bname));
                var useraccount = bank.GetAccount(bname); // Trying to find the account that i've created earlier
                useraccount.Deposit(100); // trying to add money on it
                useraccount.CheckBalance();
                Console.WriteLine("test");
            }
        }
        class Bank
        {
            private List<BankAccount> accounts = new List<BankAccount>();
            public List<BankAccount> GetAccounts()
            {
                return accounts;
            }
            public BankAccount GetAccount(string name)
            {
                return accounts.Where(x => x.name == name).FirstOrDefault();
            }
        }
        class BankAccount
        {
            private double _balance = 0;
            public string name;
            public BankAccount(string name, double balance)
            {
                this.name = name;
                this._balance = balance;
                Console.WriteLine("You succesfuly created a new account.");
            }
            public double CheckBalance()
            {
                return _balance;
            }
            public void Deposit(double n)
            {
                _balance += n;
            }
            public void WithDraw(double n)
            {
                _balance -= n;
            }
        }
    }
