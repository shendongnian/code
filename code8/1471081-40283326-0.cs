    static void Main(string[] args)
    {
        int x = 1;
        int y = 2;
        int z = 3;
        ConsoleWriteColumn(x,y,z);
        Console.WriteLine("Multiplied by 2:");
        ConsoleWriteColumn((x*2),(y*2),(z*2));
        Console.ReadKey();
    }
    static void ConsoleWriteColumn(int value1, int value2, int value3)
    {
        Console.WriteLine($"{value1,5}{value2,5}{value3,5}");
    }
