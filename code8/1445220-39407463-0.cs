    static void Main(string[] args)
    {
        var p = new Program();
        p.WrapAction(() => Console.WriteLine(123));
        Console.WriteLine(p.WrapFunc<string>(() => "321"));
        Console.ReadKey();
    }
    public void WrapAction(Action action) => WrapActionInner<object>(action);
    public T WrapFunc<T>(Func<T> func) => WrapActionInner<T>(func);
    private T WrapActionInner<T>(object action)
    {
        if (action is Action)
        {
            ((Action)action)();
            return default(T);
        }
        return ((Func<T>)action)();
    }
