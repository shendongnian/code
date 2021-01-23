    public class MyType
    {
    	public MyType()
    	{
    		Values = new Dictionary<string, object>();
    	}
    	
    	public Dictionary<string, object> Values { get; private set; }
    }
    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var connectionSettings = new ConnectionSettings(pool);
    				
    	var client = new ElasticClient(connectionSettings);
    	var myType = new MyType
    	{
    		Values =
    		{
    			{ "value1", "StringValue" },
    			{ "value2", 123 },
    			{ "value3", DateTime.Now },
    		}
    	};
    	
    	client.Index(myType, i => i.Index("index-name"));
    }
