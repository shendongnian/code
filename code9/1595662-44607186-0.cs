    public DateTime FindNextDate(int dayOfMonth, DateTime today)
    {
        var nextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
        if(dayOfMonth < today.Day){ 
          nextMonth = nextMonth.AddMonths(1);
        }
        while(nextMonth.AddDays(-1).Day < dayOfMonth){
           nextMonth = nextMonth.AddMonths(1);
        }
        var month = nextMonth.AddMonths(-1);
        return new DateTime(month.Year, month.Month, dayOfMonth);
    
    }
