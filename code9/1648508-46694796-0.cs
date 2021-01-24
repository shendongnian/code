    public class D
    {
        public static void Method<TT>(Action<TT> t) { }
        public static void Method<TT>(TT t) { }
    }
    public class RefD
    {
        public static void Method<TT>(Action<TT> t) { }
        public static void Method<TT>(TT t) { }
    }
    foreach(var sig in GetMethodSigs(typeof(RefD)))
        Console.WriteLine(GetMethodExt(typeof(D), sig.Name, sig.ParameterTypes.ToArray())?.ToString());
