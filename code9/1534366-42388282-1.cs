    private string ConvertObjectToSQL(object obj)
    {
    	if(obj is Enum)
    	{
    		return Convert.ToDecimal(obj).ToString();
    	}
    	return "";
    }
