    List<BaseClass> baseList = new List<BaseClass>();
    
    //Add some DerivedClass
    baseList.Add(new BaseClass()); 
    
    List<DerivedClass> derivedList = baseList.Select(i => new DerivedClass(i)).ToList();
