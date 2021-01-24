    var x = collection.Select(x =>
    	{
        string value = null;
        if (x != null)
        {
          value = x.Property;
        }
    
        if (value == null)
        {
          value = "default";
        }
    
        return new SomeClass(value);
    	}
    );
