    public static void Main(string[] args)
    {
        int days = 0;
        if (args.Length > 0 && int.TryParse(args[0], out days))
        {
             DateTime date= new DateTime(DateTime.Now.Year, 1, 1)
                                                   .AddDays(days-1);
             Console.WriteLine("Date: {0}",date.Day);
             Console.WriteLine("Date: {0}", date.Month);
        }
    }
