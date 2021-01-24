    public Bank()
            {
                InitializeComponent();
            }
            private List<Account> arrayAccounts = new List<Account>();
    
            private void btnCreateAccount_Click(object sender, EventArgs e)
            {
                Account account = new Account(arrayAccounts.Count + 1, Convert.ToDecimal(ammountTextBox.Text));
                arrayAccounts.Add(account);
                listBox1.Items.Add(account.ToString());
                OutputLabel.Text = "Account #" + account.AccountId + "Opened with Balance of $" + account.Balance;
            }
    
            private void btnDeposit_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listBox1.SelectedItem != null)
                    {
                        foreach (Account account in arrayAccounts)
                        {
                            if (Convert.ToInt32(listBox1.SelectedItem.ToString().Split(' ')[0]) == account.AccountId)
                            {
                                account.Deposit(Convert.ToDecimal(tbDeposit.Text));
                                refreshList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select an account!");
                    }
                }
                catch(InvalidCastException)
                {
                    MessageBox.Show("Enter valid number");
                }
            }
    
            private void btnWithdraw_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listBox1.SelectedItem != null)
                    {
                        foreach (Account account in arrayAccounts)
                        {
                            if (Convert.ToInt32(listBox1.SelectedItem.ToString().Split(' ')[0]) == account.AccountId)
                            {
                                account.Withdraw(Convert.ToDecimal(tbDeposit.Text));
                                refreshList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select an account!");
                    }
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Enter valid number");
                }
            }
    
            private void refreshList()
            {
                listBox1.Items.Clear();
                foreach(Account account in arrayAccounts)
                {
                    listBox1.Items.Add(account.ToString());
                }
            }
