    static void Main(string[] args)
    {
        Task.Factory.StartNew(() =>
        {
            First();
            Second();
            Third();
        }).Wait();
        Console.ReadLine();
    }
    static void First()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
    }
    static void Second()
    {
        //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
    }
    static void Third()
    {
        Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
    }
