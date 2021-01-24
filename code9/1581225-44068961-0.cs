    dynamic newobj = new ExpandoObject();
    
    //I can add properties during compile time such as this
    newobj.Test = "Yes";
    newobj.JValue = 123;
    
    //Or during runtime such as this (populated from two text boxes)
    AddProperty(newobj, tbName.Text, tbValue.Text);
    
    public void AddProperty(ExpandoObject expando, string name, object value)
    {
    	var exDict = expando as IDictionary<string, object>;
        if (exDict.ContainsKey(propertyName))
    		exDict[propertyName] = propertyValue;
        else
        exDict.Add(propertyName, propertyValue);
    }
