    static void Main(string[] args)
    {
        var esb = new ExtendedStringBuilder();
        esb.Append("Hi.");
        esb.Append("its me.");
        Console.WriteLine(esb.ToString());
        Console.ReadLine();
    }
