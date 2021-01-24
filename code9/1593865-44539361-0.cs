    public void AssingValue(string columnName, object target, string propertyName, int rowIndex)
    {
    	DataRow row = this.Rows[rowIndex];
    	if (row[columnName] != System.DBNull.Value) // how would I access the DataRow Value? 
    	{
    		var prop = target.GetType().GetProperty(propertyName);
    		prop.SetValue(target, Convert.ToDateTime(row[columnName]));
    	}
    
    }
