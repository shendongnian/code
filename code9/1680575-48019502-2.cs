        var xx = new List<int>();    
        xx.Add(1);      
        int xxxx = xx.Capacity;
        Console.WriteLine(xxxx); // output : 4
        xx.Add(2);      
        xx.Add(3);      
        xx.Add(4);      
        xx.Add(5);      
        xxxx = xx.Capacity;
        Console.WriteLine(xxxx); // output : 8
