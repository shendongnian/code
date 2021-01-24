    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            InvokeMethod(null, typeof(Program), "M1", "foo");
            InvokeMethod(null, typeof(Program), "M2", 17, "bar");
            InvokeMethod(program, typeof(Program), "M3", false);
        }
        static void M1(string text)
        {
            WriteLine($"M1: {text}");
        }
        static void M2(int i, string text)
        {
            WriteLine($"M2: {i}, {text}");
        }
        void M3(bool f)
        {
            WriteLine($"M3: {f}");
        }
        static void InvokeMethod(object instance, Type type, string methodName, params object[] args)
        {
            Delegate d = CreateDelegate(instance, type, methodName);
            d.DynamicInvoke(args);
        }
        static Delegate CreateDelegate(object instance, Type type, string methodName)
        {
            MethodInfo mi = type.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            Type delegateType = Expression.GetDelegateType(mi.GetParameters()
                .Select(pi => pi.ParameterType)
                .Concat(new[] { mi.ReturnType }).ToArray());
            return Delegate.CreateDelegate(delegateType, instance, mi);
        }
    }
