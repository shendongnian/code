    private void GetDateRanges(int monthsBack = 18)
    {
        List<string> dateList= new List<string>();
        DateTime dt = DateTime.Now;
        for (int i = 1; i <= monthsBack; i++)
        {
            dt = dt.AddMonths(-1);
            dateList.Add(dt.ToString("MMMM-yyyy"));
        }
    
        return dateList;
    }
