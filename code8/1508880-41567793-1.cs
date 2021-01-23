    var data2 = ConfigurationManager.GetSection("MyConfig1");
    var nvc = (NameValuesCollection)data2;
    foreach (var keyname in nvc.Keys)
    {
        Console.Write("Node Name: {0} = [" , keyname);
        foreach(var val in nvc[keyname])
        {
             Console.Write("{0};", val);
        }
        Console.WriteLine("]");
     }
            
