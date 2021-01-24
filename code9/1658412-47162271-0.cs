    private void Translate(object o)
    {
    	var t = o.GetType();
     	var props = t.GetProperties();
     	foreach (var prop in props)
     	{
     		var propattr = prop.GetCustomAttributes(false);
     		var shouldTranslate = propattr.Any(row => row.GetType() == typeof(TranslateAttribute));
     		if (shouldTranslate)
    		{
    			var value = (string)prop.GetValue(o, null);
    			if (value != null)
    			{
    				prop.SetValue(o, MyTranslationService(value));
    			}
    		}
    	}
    }
    
    private String MyTranslationService(String s)
    {
    	return s + " :)";
    }
