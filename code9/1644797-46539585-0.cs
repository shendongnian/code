    public void MyDelegate<T>(IMyInterface<T> pParam)
    {
          
    }
    void myFunction()
    {
        //admit vMyObject is IMyInterface<ClassA>
        var vMyObject = vObj as IMyInterface<ClassA>;
        //get the generic type => ClassA
        var vTypeGeneric = vTypeReturn.GenericTypeArguments.FirstOrDefault();
        //build the type handler for the event MyHandler<ClassA>
        Type vAsyncOP = typeof(MyHandler<>).MakeGenericType(vTypeGeneric);
    
        // SOLUTION here :
        // Create MyDelegate<vTypeGeneric>
        // Then instanciate it with CreateDelegate and typeof(IMyInterface<vTypeGeneric>)
        var vMyDelegate= this.GetType().GetMethod("MyDelegate");
        var vMyDelegateGeneric = vMyDelegate.MakeGenericMethod(vTypeGeneric);
        Type vTypeHandlerGeneric = typeof(IMyInterface<>).MakeGenericType(vTypeGeneric);
        // this => bind to method in the class
        var vMethodDelegate = vMyDelegateGeneric.CreateDelegate(vTypeHandlerGeneric, this);
        // Set delegate Property
        var vEventFired = vMyObject.GetType().GetProperty("EventFired");
        vEventFired.SetValue(value, vDelegate);
    
    }
