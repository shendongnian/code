    public class SnakeCaseJsonFormatter : JsonMediaTypeFormatter
    {
    	public SnakeCaseJsonFormatter()
    	{
    		SerializerSettings = new JsonSerializerSettings
    		{
    			ContractResolver = new DefaultContractResolver
    			{
    				NamingStrategy = new SnakeCaseNamingStrategy()
    			}
    		};
    	}
    
    	public override bool CanWriteType(Type type)
    	{
    		return false;
    	}
    
    	public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    	{
    		throw new NotImplementedException();
    	}
    }
