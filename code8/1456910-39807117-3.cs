    static void Main(string[] args)
    {
        var o = new object();
        Foo(o);
        //At this pont the list created in Foo(o) is eligible for collection, even if
        //o is not! Collecting the list does not mean that its contents are collected too. 
        Console.WriteLine(o.ToString());
    }
    private static void Foo(object o)
    {
        var list = new MyList<object>(10000);
        list.Add(o);
    } //list is eligible for collection!
