    public static DateTime GetDateTime()
    {
        DateTime X;
        String Result = Console.ReadLine();
        while(!DateTime.TryParse(Result, out X))
        {
           Console.WriteLine("Not a valid DateTime, try again.");
           Result = Console.ReadLine();
        }
        return X;
    }
