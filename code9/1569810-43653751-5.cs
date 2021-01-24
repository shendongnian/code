    [Test]
    public void Total_PropertyChanged_Is_Raised_When_Account1_Balance_Is_Changed()
    {
        var bank = new Bank(new Account(), new Account());
        bank.Account1.Balance += 10;
        Assert.PropertyChanged(bank, nameof(Bank.Total));
    }
