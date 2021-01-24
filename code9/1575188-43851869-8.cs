    public void Get()
    {
        typename = ESIGenericRequests.GetTypeNameAsString(typeid).GetAwaiter().GetResult();
        systemname = ESIGenericRequests.GetSystemNameAsString(systemid).GetAwaiter().GetResult();
        Console.WriteLine("inside the formerly-async void method" + typename + " " + systemname);
    }
    
