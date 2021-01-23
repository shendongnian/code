    void UpdateValues<T>(T obj,  Dictionary<string, string> values)
    {
    	foreach (var value in values)
    	{		
    		SetProperty(obj, value.Key, value.Value);
    	}
    }
    
    
    public void SetProperty<T>( T obj, string valueKey, string value, Type type= null)
    {
    	var typeToUse = type ?? typeof(T);
    	var pointIndex = valueKey.IndexOf(".");
    	if (pointIndex!=-1)
    	{
    		var subKey = valueKey.Substring(0, pointIndex);
    		subKey.Dump();
    		var fieldInfo = typeToUse.GetField(subKey);
            var propObj =  fieldInfo.GetValue(obj)?? Activator.CreateInstance(fieldInfo.FieldType);			
    		SetProperty(propObj, valueKey.Substring(pointIndex+1), value, fieldInfo.FieldType);
    		fieldInfo.SetValue(obj, propObj);
    	}
    	else
    	{		
    		var fieldInfo = typeToUse.GetField(valueKey);		
    		if (fieldInfo != null)
    			fieldInfo.SetValue(obj, value);
    	}
    }
