    int FuncA(int num, object[] x)
    {
        if (x.Length == 0 || x.Length > 32) throw new ArgumentOutOfRangeException();
        IEnumerable<Type> types = new[] { typeof(string) }.Concat(x.Select(i => typeof(object)));
        MethodInfo info = typeof(FuncBClass).GetMethod("FuncB", types.ToArray());
        IEnumerable<object> parameters = new[] { "Some string" }.Concat(x);
        object result = info.Invoke(null /* ignored if the method is static */, parameters.ToArray());
        return (int)result;
    }
