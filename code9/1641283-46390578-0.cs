    static void Main(string[] args)
    {
        var str = "41";
        var i = int.Parse(str, NumberStyles.HexNumber);
        // Prints the char "A"
        Console.WriteLine((char) i);
    }
