    public static List<T> GetModelsByAttribute<T,R>(string propertyName, R attribute, string attributeName) where T : YourAttributeClass
    {
    	var connection = new OracleTestConnection();
    	var property = (List<T>)connection.GetType().GetProperty(propertyName).GetValue(connection, null);
    	return property.Where(d => d.attributeName == att).ToList(); // assuming your class YourAttributeClass has attributeName property
    }
