    private void RefreshGrid(Type t, DataGridView ctl)
    {
    	var openGenericType = typeof(DataController<>);
    	var genericType = openGenericType.MakeGenericType(t);
    	var instance = Activator.CreateInstance(genericType); //Instance is type of DataController<T> where T is type of "t"
    	//If you need to access instance's members, you can use System.Reflection
    	//Other stuff...
    
    	instance = null;
    }
