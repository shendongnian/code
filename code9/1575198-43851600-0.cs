    static void Main(string[] args)
    {
        Random random = new Random();
        int count = 10;
        char[] plusesAndMinuses = new int[count]
            .Select(i => random.Next())
            .Select(i => i % 2 == 0 ? '+' : '-')
            .ToArray();
        string result = new string(plusesAndMinuses);
        Console.WriteLine(result);
    }
