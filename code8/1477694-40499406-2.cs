    private void ApplyButton_Click(object sender, EventArgs e)
    {
        double userInput = Convert.ToDouble(AmountInput.Text);
        if (DepositRButton.Checked)
        {
            CustomerList[0].Deposit(userInput);
        }
    }
