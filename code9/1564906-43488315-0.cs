    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace Bank
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private int _nextIndex = 0;
            private Account[] _accounts = new Account[19];
            private void createButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(accountIdTextBox.Text)) return;
                var account = new Account();
                int accountID;
                int balance=0;
                bool success=int.TryParse(accountIdTextBox.Text,out accountID);
                int.TryParse(amountTextBox.Text, out balance);
                if(success)
                {
                    account.AccountId = accountID;
                    account.Balance = balance;
                    _accounts[_nextIndex] = account;
                    _nextIndex++;
                }
                resultLabel.Text = "Created Account: " + accountID + " with Balance " + balance;
            }
            private Account GetAccount(int id)
            {
                return _accounts.Where(x => x.AccountId == id).FirstOrDefault();
            }
            private void depositButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(accountIdTextBox.Text)) return;
                int amount = 0;
                int accountID;
                bool success1 = int.TryParse(accountIdTextBox.Text, out accountID);
                bool success2 = int.TryParse(amountTextBox.Text, out amount);
                if(success1 && success2 && amount >0)
                {
                    var selectedAccount = GetAccount(accountID);
                    selectedAccount.Balance += amount;
                    resultLabel.Text = "Account: " + accountID + " balance get deposit for " + amount;
                }
            }
            private void withdrawButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(accountIdTextBox.Text)) return;
                int amount = 0;
                int accountID;
                bool success1 = int.TryParse(accountIdTextBox.Text, out accountID);
                bool success2 = int.TryParse(amountTextBox.Text, out amount);
                if (success1 && success2 && amount > 0)
                {
                    var selectedAccount = GetAccount(accountID);
                    selectedAccount.Balance -= amount;
                    resultLabel.Text = "Account: " + accountID + " balance withdrawed by " + amount;
                }
            }
            private void ballanceButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(accountIdTextBox.Text)) return;
                int amount = 0;
                int accountID;
                bool success1 = int.TryParse(accountIdTextBox.Text, out accountID);
                if (success1)
                {
                    var selectedAccount = GetAccount(accountID);
                    resultLabel.Text = "Account: " + accountID + ", Balance: " + selectedAccount.Balance;
                }
            }
        }
    }
