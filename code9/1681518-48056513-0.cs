    Type type = typeof(MyClass);
    
    MyClass instance = (MyClass)Activator.Create(type);
    
    //method example
    public void ClassGet(string MyClassName,string blabla)
    {
        object instance = Activator.Create(MyClassName);
    }
    
    // Call it like:
    
    Gold g = new Gold();
    g.ClassGet("MyClass", "blabla");
