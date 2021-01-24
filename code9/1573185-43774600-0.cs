    public static Func<DateTime, string> A = (date) => { return date.ToString(); };
    public static Func<DateTime, string> B = (date) => { return date.ToString(); };
    public static Func<DateTime, string> C = (date) => { return A(date) + B(date); };
    static void Main(string[] args)
    {
        var date = DateTime.Now;
        Console.WriteLine(C(date));
    }
