    public static DateTime Add(int daysToAdd, DateTime date)
    {
        return date.AddDays(daysToAdd);
    }
    private static void Main()
    {
        // Call the method passing the int first, then the DateTime
        var newDate1 = Add(daysToAdd: 5, date: DateTime.Now);
        // Call the method passing the DateTime first, then the int 
        var newDate2 = Add(date: DateTime.Now, daysToAdd: 5);
    }
