    static void Main(string[] args)
    {
        so42112722 test = new so42112722();
        Console.WriteLine("Comparing ConcurrentDictionary to PLinq:");
        for (int i = 0; i < 10; i++)
        {
            test.RunTest();
        }
        Console.ReadLine();
    }
