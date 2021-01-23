    [Flags]
    public enum frequencyDaysEnum
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
    // You can also add these but they are not necessary
    //    WeekDays = 62,
    //    WeekEnds = 65,
    //    EveryDay = 127
    }
    void Main()
    {
        int value = 65; // <= this is the value of your property
        frequencyDaysEnum days = (frequencyDaysEnum)value;
        
        if(days.HasFlag(frequencyDaysEnum.Saturday))
            Console.WriteLine("It has frequency on Saturday");
    
        if (days.HasFlag(frequencyDaysEnum.Sunday))
            Console.WriteLine("It has frequency on Sunday");
    }
