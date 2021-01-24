    public async void GetAsync()
    {
        typename = ESIGenericRequests.GetTypeNameAsString(typeid).GetAwaiter().GetResult();
        systemname = ESIGenericRequests.GetSystemNameAsString(systemid).GetAwaiter().GetResult();
        Console.WriteLine("inside the async void method" + typename + " " + systemname);
    }
    
