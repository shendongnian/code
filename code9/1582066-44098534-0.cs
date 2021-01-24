    List<BaseClass> baseList = new List<BaseClass>();
    
    //Add some DerivedClass
    baseList.Add(new DerivedClass());
    baseList.Add(new DerivedClass());
    
    List<DerivedClass> derivedList = baseList.Cast<DerivedClass>().ToList();
