    public T KeepElementsData()
    {
        var item = new T();
        //Propertys durchlaufen
        foreach (var property in item.GetType().GetProperties())
        {
            property.SetValue(item, "TestData");  //this works
        }
        //Fields durchlaufen
        foreach (var field in item.GetType().GetFields())
        {
            var value = field.GetValue(item);
            var type = value.GetType();
            foreach (var fieldProperty in type.GetProperties())
            {
                fieldProperty.SetValue(value, "TestData works");
            }
        }
        return item;
    }
