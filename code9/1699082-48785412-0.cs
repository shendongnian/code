    static void Main(string[] args)
    {
        Console.WriteLine(Method().Result);
    }
    public static async Task<int> Method()
    {
        List<int> ints = null;
        int a = ints.Where(x => x == 10).Single();
        return a;
    }
