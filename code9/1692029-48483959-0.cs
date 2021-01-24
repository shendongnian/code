    static void func()
    {
        foreach (var type in typeof(Program).Assembly.GetTypes())
        {
            var attrs = type.GetCustomAttributes(typeof(A)).ToList();
            if(attrs.Any())
            {
                A attr = attrs.First() as A;
                dic.Add(type, () => attr.SayHi());
            }
        }
    }
