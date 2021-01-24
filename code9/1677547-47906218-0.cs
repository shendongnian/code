    public void Add(Derived1 item)
    {
        if(items.OfType<Derived1>().Any(i => i.DerivedProperty1 == item.DerivedProperty1)
            throw new InvalidOperationException("An item with the same DerivedProperty1 already exist"); 
         items.Add(baseItem);
    }
    public void Add(Derived2 item)
    {
        if(items.OfType<Derived2>().Any(i => i.DerivedProperty2 == item.DerivedProperty2)
            throw new InvalidOperationException("An item with the same DerivedProperty2 already exist"); 
         items.Add(baseItem);
    }
