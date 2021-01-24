    Foo f = new Foo(100);
    Foo f2 = (Foo)f.Clone();
    
    f2.MyBar.Value = 200;
    
    Console.WriteLine(f.MyBar.Value); // 200
    Console.WriteLine(f2.MyBar.Value); // 200
