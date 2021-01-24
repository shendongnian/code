    public void Foo(object o)
    {
        if (o is int)
            ((Base)this).Foo((int)o));
        else
            Console.WriteLine("Derived.Foo(object)");
    }
