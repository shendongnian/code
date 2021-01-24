    public static void Test1()
    {
        // Class A overlaps class B
        DateTime aStart = DateTime.Parse("2017-01-01T09:00:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T10:00:00");
        DateTime bStart = DateTime.Parse("2017-01-01T09:30:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T11:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == true;
        Console.WriteLine($"1: {isCorrect}");
    }
    public static void Test2()
    {
        // Class A "surrounds" class B
        DateTime aStart = DateTime.Parse("2017-01-01T09:00:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T15:00:00");
        DateTime bStart = DateTime.Parse("2017-01-01T09:30:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T11:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == true;
        Console.WriteLine($"2: {isCorrect}");
    }
    public static void Test3()
    {
        // Class B "surrounds" class A
        DateTime aStart = DateTime.Parse("2017-01-01T09:30:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T11:00:00");
        DateTime bStart = DateTime.Parse("2017-01-01T09:00:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T15:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == true;
        Console.WriteLine($"3: {isCorrect}");
    }
    public static void Test4()
    {
        // Class A is before Class B
        DateTime aStart = DateTime.Parse("2017-01-01T09:00:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T11:00:00");
        DateTime bStart = DateTime.Parse("2017-01-01T11:00:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T12:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == false;
        Console.WriteLine($"4: {isCorrect}");
    }
    public static void Test5()
    {
        // Class A is after Class B
        DateTime aStart = DateTime.Parse("2017-01-01T12:00:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T14:00:00");
        DateTime bStart = DateTime.Parse("2017-01-01T11:00:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T12:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == false;
        Console.WriteLine($"5: {isCorrect}");
    }
    public static void Test6()
    {
        // Class B overlaps class A
        DateTime bStart = DateTime.Parse("2017-01-01T09:00:00");
        DateTime bEnd = DateTime.Parse("2017-01-01T10:00:00");
        DateTime aStart = DateTime.Parse("2017-01-01T09:30:00");
        DateTime aEnd = DateTime.Parse("2017-01-01T11:00:00");
        bool isCorrect = HasOverlap(aStart, aEnd, bStart, bEnd) == true;
        Console.WriteLine($"6: {isCorrect}");
    }
    static void Main()
    {
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        Test6();
        Console.Read();
    }
