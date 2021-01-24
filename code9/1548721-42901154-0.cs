    public void event1(object1 sender, eventArgs e1)
    {
        var myParameter = ...;
        Method1(myParameter);
    }
    public static void Method1(object myParameter)
    {
        // code goes here
    }
    
    public void event2(object2 sender, eventArgs e2)
    {
        var myParameter = ...;
        Method2(myParameter);
    }
    public static void Method2(object myParameter)
    {
        Namespace1.Class1.Method1(myParameter);
    }
