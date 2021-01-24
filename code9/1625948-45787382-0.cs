    static void Main(string[] args)
    {
        string mainString = "11;22;33;44;55;66";
        string[] array = mainString.Split(";");
        foreach (var s in array)
        {
            System.Console.WriteLine(s);
        }
        Console.ReadKey();
    }
