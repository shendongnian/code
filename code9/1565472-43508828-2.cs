    public int verifyHour(DateTime datetime)
    {
       if(datetime.Hour == 20 && datetime.Minute >= 25 && datetime.Minute <= 30)
       {
           return 1;
       }
       else(datetime.Hour <= 8 && datetime.Hour <= 18)
       {
           return datetime.Hour - 6;
       }
       return -1;
    }
