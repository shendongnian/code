    if (!string.IsNullOrWhiteSpace(TXTCustomerGrowth.Text))
    {
        fm.SaveGrowth(Convert.ToDouble(TXTCustomerGrowth.Text));
    }
    else
    {
        fm.SaveGrowth(0);
    }
