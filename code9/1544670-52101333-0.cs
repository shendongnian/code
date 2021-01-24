    public class DataConverter : IPropertyConverter
    {
    	public object FromEntry(DynamoDBEntry entry)
    	{
    		var primitive = entry as Primitive;
    		if (primitive == null || !(primitive.Value is String) || string.IsNullOrEmpty((string)primitive.Value))
    			throw new ArgumentOutOfRangeException();
    		object ret = JsonConvert.DeserializeObject(primitive.Value as string);
    		return ret;
    	}
    
    	public DynamoDBEntry ToEntry(object value)
    	{
    		var jsonString = JsonConvert.SerializeObject(value);
    		DynamoDBEntry ret = new Primitive(jsonString);
    		return ret;
    	}
    }
