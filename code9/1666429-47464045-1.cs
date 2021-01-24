    static void Main(string[] args)
    {
        var pattern = @"^(aa|bb){1}(a*)(ab){1}$";
            
        Console.WriteLine(FindBestValidRegex("bbb", pattern));
        Console.WriteLine(FindBestValidRegex("aabb", pattern));
        Console.WriteLine(FindBestValidRegex("aaab", pattern));
        Console.WriteLine(FindBestValidRegex("bbaab", pattern));
        Console.ReadKey();
    }
