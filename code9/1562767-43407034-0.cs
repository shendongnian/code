    public static T GetInfo<T>(string name, Func<string, T> convert)
    {
        Console.WriteLine("Please enter " + name);
        string input = Console.ReadLine();
        return convert(input);
    }
