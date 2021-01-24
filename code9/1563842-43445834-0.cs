    StokItem item = new StokItem();
    item.prop1 = 123;
    item.prop2 = 456;
    ...
    
    foreach (var prop in item.GetType().GetProperties())
    {
    	//string propertyName = prop.Name;
    	//var propertyValue = prop.GetValue(item);
        ScCommand.Parameters.AddWithValue ("@" + prop.Name, prop.GetValue(item));
    }
