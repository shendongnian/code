    using System.Reflection;
    using System.Diagnostics;
    static void Log(string msg)
    {
        var method = new StackFrame(1).GetMethod();
        Console.WriteLine("{0}.{1}: {2}", method.ReflectedType.FullName, method.Name, msg);
    }
