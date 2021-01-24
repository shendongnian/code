    int FuncA(int num, object[] x)
    {
        if (x.Length == 0 || x.Length > 32) throw new ArgumentOutOfRangeException();
        IEnumerable<Type> types = new[] { typeof(string) }.Concat(x.Select(i => typeof(object)));
        MethodInfo info = typeof(int).GetMethod("FuncB", types.ToArray());
        object[] parameters = new[] { "Some string", null /* the out parameter */ }.Concat(x.Skip(1)).ToArray();
        info.Invoke(null /* ignored if the method is static */, parameters);
        return (int)parameters[1]; // Get the out parameter value and cast it
    }
