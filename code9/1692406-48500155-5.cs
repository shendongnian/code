    public static void DoSomething(Parent P)
    {
        dynamic @dynamic = P;
        DoSomethingElse(@dynamic);
    }
    public static void DoSomethingElse(Parent @dynamic)
    {
        // T is 'Parent'
        var type = @dynamic.GetType();
        dynamic R = Activator.CreateInstance(type); // want R to be 'Child1' or 'Child2'
    }
