    using System.Reflection;
    static void Log(MethodBase method, string msg)
    {
        Console.WriteLine("{0}.{1}: {2}", method.ReflectedType.FullName, method.Name, msg);
    }
