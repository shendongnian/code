    public int VerifyHour(string hourminute)
    {
        DateTime datetime;
        if (DateTime.TryParse(hourminute, out datetime))
        {
            int result = datetime.Hour;
            if(datetime.Hour == 20 && datetime.Minute >= 25 && datetime.Minute <= 30)
            {
                 return 1;
            }
            else(datetime.Hour <= 8 && datetime.Hour <= 18)
            {
                 return datetime.Hour - 6;
            }
        }
        return -1;
    }
