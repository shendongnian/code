    public static void Main(string[] args)
    {
        var s = "some user input";
        Regex r =  new Regex(@"\W|_");
        var x = r.Replace(s, "_");
        Console.WriteLine(x);
        Console.WriteLine(r.Replace("http://google.com?s=search query here", "_"));
    }
