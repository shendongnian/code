        var dt = new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
        
        var now = System.DateTime.Now.ToUniversalTime();
        var future = new DateTime(2010, 1, 1).ToUniversalTime();
        
        Console.WriteLine((now - dt).TotalSeconds);
        Console.WriteLine((future - dt).TotalSeconds);
