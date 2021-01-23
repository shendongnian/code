    static void Main(string[] args)
    {
        var o = new object();
        Foo(o);
        //At this point the list created in Foo(o) is eligible for collection, even if
        //o is not! Collecting the list does not mean that its contents are collected too. 
        Console.WriteLine(o.ToString());
    }
    private static void Foo(object o)
    {
        var list = new MyList<object>();
        list.Add(o);
    } //at this point list is eligible for collection!
