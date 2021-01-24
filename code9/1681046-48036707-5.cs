    [WebMethod]
    [ScriptMethod]
    public static string GetCurrentTime(RootObject list)
    {
    	string str = "";
    	foreach (var s in list.name)
    	{
    		str += s.Value;
    	}
    	return str;
    }
     
         
