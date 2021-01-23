    DateTime cardExpiry;
    bool validDate = DateTime.TryParseExact(expiry.Text, "MM/yy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out cardExpiry);
    if (!validDate)
    {
        MessageBox.Show("Enter a valid card expiry month in the format 'MM/yy', for example 01/17");
        return;
    }
    cardExpiry = cardExpiry.AddMonths(1).AddSeconds(-1); // last date of month, 23:59:59
    // ...
