    public void M() 
    {
        var item = Console.Read();
        Func<object, object> ok = OnAction; // will work
        Func<object, object> handler = 
            item == 1 ? OnAction : throw new Exception(); // will not work
    }
    
    public static Object OnAction(object y)
    {
        return "";
    }
