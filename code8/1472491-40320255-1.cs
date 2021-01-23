    if ((dtpFromDate.Value.Ticks / TimeSpan.TicksPerSecond) > 
         (dtpToDate.Value.Ticks / TimeSpan.TicksPerSecond))
    {
       MessageBox.Show("From Date is greater than To Date");
       return;
    }
