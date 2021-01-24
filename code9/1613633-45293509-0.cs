    // Days in previous Month
    int daysMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1); 
    MessageBox.Show(daysMonth.ToString());
    // Days in Previous Year
    int daysYear = DateTime.DaysInyear(DateTime.Now.Year - 1);
    MessageBox.Show(daysYear.ToString());
