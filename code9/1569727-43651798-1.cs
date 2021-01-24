    var item = new T();
    //Propertys durchlaufen
    foreach (var property in item.GetType().GetProperties())
    {
        property.SetValue(item, "TestData");  //this works
    }
    
    //Fields durchlaufen
    foreach (var field in item.GetType().GetFields())
    {
        field.SetValue(item, "TestData");
    }
