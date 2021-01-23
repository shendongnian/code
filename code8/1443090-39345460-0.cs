    public void GetMonthAmount(string month)
    {
        string keyName = month + "TotalAmount";
        object monthData = Properties.Settings.Default[keyName];
    }
