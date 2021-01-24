    void Main()
    {
    	var serializer = new JavaScriptSerializer();
    	Console.WriteLine(serializer.Serialize(new TestObject { TestString = "test" })); // prints: {}
    	serializer.RegisterConverters(new List<JavaScriptConverter> { new TestObjectConverter() });
    	Console.WriteLine(serializer.Serialize(new TestObject { TestString = "test" })); // prints: {"TestString":"test"}
    }
    
    public class TestObject
    {
    	[ScriptIgnore]
    	public string TestString { get; set; }
    }
    
    public class TestObjectConverter : JavaScriptConverter
    {
    	private static readonly IEnumerable<Type> supportedTypes = new List<Type> { typeof(TestObject) };
    	
    	public override IEnumerable<Type> SupportedTypes => supportedTypes;
    
    	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    	{
    		var testObject = obj as TestObject;
    
    		if (testObject != null)
    		{
    			// Create the representation. This is a simplified example. You can use reflection or hard code all properties to be written or do it any other way you like - up to you.
    			Dictionary<string, object> result = new Dictionary<string, object>();
    			result.Add("TestString", testObject.TestString);		
    			return result;
    		}
    		
    		return new Dictionary<string, object>();
    	}
    }
