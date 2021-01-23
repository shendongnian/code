    static void Main()
    {
        string pattern = @"\/[a-zA-Z]+\/[a-zA-Z]+\/[a-zA-Z]+\/([0-9]+)\/[a-z0-9]+";
        var regex = new Regex(pattern);
        string path = "/fa/Viewer/Switcher/60684/0";
        var match = regex.Match(path);
        Console.WriteLine(match.Groups[1].ToString());
    }
