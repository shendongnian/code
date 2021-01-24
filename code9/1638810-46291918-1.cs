    var u = new Unicorn();
    u.State = new GoodUnicornState();
    Console.WriteLine(u.Rainbow);
    u.State = u.State.Change();
    Console.WriteLine(u.Rainbow);    
