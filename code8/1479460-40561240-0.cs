    static void Main(string[] args)
    {
        string[] ar = new string[] { "hello", "world", "people" };
        string output = writeString(ar);
        Console.WriteLine(output);
        Console.ReadLine();
    }
    static string writeString(string[] ar)
    {
        string a1 = " ";
        foreach (string a in ar)
        {
            a1 = a1 + a;
        }
        return a1;
    }
