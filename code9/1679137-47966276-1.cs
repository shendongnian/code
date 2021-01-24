    Base b;
    Derived d;
    int x;
    
    b = new Derived();
    d = new Derived();
    
    x = b.GetInt(); // x = 10 [Base.GetInt()]
    x = d.GetInt(); // x = 11 [Derived.GetInt()]
