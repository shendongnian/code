    public MyModel SetNotAvailable(MyModel obj)
    {
    	var properties = obj.GetType().GetProperties();
    	foreach(var property in properties){
    		if(property.PropertyType.Equals(typeof(string)))
    		{
    			var value = property.GetVale(obj, null).ToString();
    			if(string.IsNullOrEmpty(value))
    				property.SetValue(obj, "Not Available");
    		}
    	}
    	return obj;
    }
