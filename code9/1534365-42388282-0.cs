    private string ConvertObjectToSQL(object obj)
    {
    	if(obj is Enum)
    	{
    		return ((int)obj).ToString();
    	}
    	return "";
    }
