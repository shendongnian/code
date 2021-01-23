    public static bool canCancel(string date)
    {
        DateTime booking = Convert.ToDateTime(date);
        DateTime ending = booking.AddHours(23).AddMinutes(59).AddSeconds(59);
    
        var n = DateTime.Compare(ending, DateTime.Now);
        if(n == -1)
        {
           // within 24 hour from booking
           // so can not cancel
           return false;
        }
        else
        {
           // greater than 24 hour
           // so can cancel
           return true;
        }
      
      
    }
