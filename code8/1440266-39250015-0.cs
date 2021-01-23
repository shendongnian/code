    // instance of DerivedClass exposing its full contract via the 'dc' variable
    DerivedClass dc = new DerivedClass();
    // the same instance of DerivedClass exposing its contract limited to what's declared in BaseClass
    BaseClass bc = dc;
    // calling Method2 as newly declared in DerivedClass
    dc.Method2();
    
    // calling Method2 as declared in BaseClass—the following two lines are equivalent
    bc.Method2();
    ((BaseClass)dc).Method2();
