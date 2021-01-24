    try
    {
        var dll = Assembly.LoadFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WpfLibrary.dll"));
        var type = dll.GetType("WpfLibrary.TestWindow");
        var instance = Activator.CreateInstance(type);
        object[] parameters = { };
        instance.GetType().InvokeMember("Start2", BindingFlags.InvokeMethod, null, instance, parameters);
    }
    catch(Exception exception)
    {
        //handle exception
    }
