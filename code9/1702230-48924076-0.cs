    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            List<Account> accountList;
            DataGridView dataGridViewAccounts;
            ListBox listBoxNames;
            public Form1()
            {
                //InitializeComponent();
                Size = new Size(400, 350);
                accountList = new List<Account>();
                dataGridViewAccounts = new DataGridView { Parent = this, Dock = DockStyle.Left };
                listBoxNames = new ListBox { Parent = this, Dock = DockStyle.Right };
                Load += Form1_Load;                
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                Random rand = new Random();
                string[] names = new string[] {
                    "Josh", "Waylon", "Alan", "Jack", "John", "Elaine", "Monica", "Kaithe", "Kim", "Jazy" };
                for (int i = 1; i <= 10; i++)
                {
                    int accountNumber = i;
                    decimal accountBalance = rand.Next(0, 10);
                    string[] accountNames = names.Select(n => n + i).ToArray();
                    var account = new Account(accountNumber, accountBalance, accountNames);
                    accountList.Add(account);
                }
                var bindingSourceAccounts = new BindingSource();
                bindingSourceAccounts.DataSource = accountList;
                var bindingSourceNames = new BindingSource(bindingSourceAccounts, "Names");
                dataGridViewAccounts.DataSource = bindingSourceAccounts;
                listBoxNames.DataSource = bindingSourceNames;
            }
        }
        public class Account
        {
            public Account(int number, decimal balance, string[] names)
            {
                Number = number;
                Balance = balance;
                Names = names;
            }
            public int Number { get; set; }
            public decimal Balance { get; set; }
            public string[] Names { get; set; }
        }
    }
