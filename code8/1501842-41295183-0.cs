    Dictionary<string, object> lst = new Dictionary<string, object>();
    try
    {
    	foreach (DataRow row in dt.Rows)
    	{
    		//Adds time as key and Inuse as value in dictionary
    		lst.Add(row["Time"].ToString(), row["Inuse"] as string);
    	}
    }
    catch (Exception ex)
    {
    	throw ex;
    }
