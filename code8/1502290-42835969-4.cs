    Session.Data = new Dictionary<string,object>() {{"value", 1}}
    Console.WriteLine(Session.Data["value"].toString()); // will be 1
    Task manager1 = Task.Run(async () => 
    {
        Console.WriteLine(Session.Data["value"].toString()); // will be 1
        Session.Data = new Dictionary<string,object>() {{"value", 2}}
        Console.WriteLine(Session.Data["value"].toString()); // will be 2
        Task manager2 = Task.Run(async () => 
        {
            Console.WriteLine(Session.Data["value"].toString()); // will be 2
            Session.Data = new Dictionary<string,object>() {{"value", 3}}
            Console.WriteLine(Session.Data["value"].toString()); // will be 3
        }
   
        Task manager3 = Task.Run(async () => 
        {
            Console.WriteLine(Session.Data["value"].toString()); // will be 2
            Session.Data = new Dictionary<string,object>() {{"value", 4}}
            Console.WriteLine(Session.Data["value"].toString()); // will be 4
        }
        Console.WriteLine(Session.Data["value"].toString()); // will be 2
    }
    Console.WriteLine(Session.Data["value"].toString()); // will be 1
