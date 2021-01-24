    static void Main()
    {
        Class1 c = new Class1();
        Del mydel = c.Add2;
        mydel += c.Add3;
        mydel += c.Add2;
        int result = 3;
        foreach (var func in mydel.GetInvocationList())
        {
            result = (int)func.DynamicInvoke(result);
        }
        Console.WriteLine(result);
    }
