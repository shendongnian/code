    private static void TestLogAnyMethod()
    {
        Console.WriteLine("\r\n>> First batch >>");
        var x = M1(0, 1.1);
        var y = M2("a", true);
        var z = M2(GetA(4, 5.0 / 7.0), GetTrue());
        Console.WriteLine("\r\n>> Second batch >>");
        var x2 = Log(() => M1(0, 1.1));
        var y2 = Log(() => M2("a", true));
        var z2 = Log(() => M2(GetA(4, 5.0 / 7.0), GetTrue()));
        Console.WriteLine("\r\n>> Results >>");
        Console.WriteLine(x + " == " + x2);
        Console.WriteLine(y + " == " + y2);
        Console.WriteLine(z + " == " + z2);
    }
    private static string GetA(int p, double q)
    {
        Console.WriteLine("-- Executing GetA");
        return "a";
    }
    private static bool GetTrue()
    {
        Console.WriteLine("-- Executing GetTrue");
        return true;
    }
    private static string M1(int v1, double v2)
    {
        return "123abc";
    }
    private static bool M2(string w1, bool w2)
    {
        return true;
    }
    private static T Log<T>(Expression<Func<T>> expr)
    {
        var funcBody = (MethodCallExpression)expr.Body;
        var funcArgs = funcBody.Arguments;
        Console.WriteLine("Method call: " + funcBody.Method.Name + "(" + string.Join(", ", funcArgs.Select(p => p.ToString())) + ")");
        Func<T> f = expr.Compile();
        return f();
    }
