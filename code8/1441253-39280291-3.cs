    static void Main()
    {
        Foo foo1 = null;
        Bar bar2 = null;
        Examine<Foo>(x => (Func<int,bool>)foo1.Test1);
        Examine<Bar>(x => (Func<string,string,string>)bar2.DifferentMethod2);
    }
    public static void Examine<T>(Expression<Func<T, Delegate>> expression2)
    {
        // examine expression tree to get method name (MethodInfo)
    }
