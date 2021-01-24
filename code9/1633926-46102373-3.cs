    static void Main(string[] args)
    {
        List<string> list = new List<string>("cat,dog,rat".Split(','));
        Console.WriteLine(list.FindItemAfter("cat"));
        Console.WriteLine(list.FindItemAfter("dog"));
        Console.ReadLine();
    }
