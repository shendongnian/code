    static void Main(string[] args)
    {
        var list = "cat,dog,rat".Split(',');
        Console.WriteLine(list.FindItemAfter("cat"));
        Console.WriteLine(list.FindItemAfter("dog"));
        Console.ReadLine();
    }
