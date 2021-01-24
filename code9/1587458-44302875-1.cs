    var dt = typeof(DateTime);            
    var nd = typeof(DateTime?);
            
    Console.WriteLine(dt.IsAssignableFrom(nd)); // false
    Console.WriteLine(nd.IsAssignableFrom(dt)); //true
