    public class ResultConverter : JavaScriptConverter
    {
    	private static readonly IEnumerable<Type> supportedTypes = new List<Type> { typeof(Warnings) };
    	
    	public override IEnumerable<Type> SupportedTypes => supportedTypes;
    
    	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    	{
    		var warningsDictionary = dictionary["warnings"] as IDictionary<string, object>;
    		var loginDictionary = warningsDictionary["login"] as IDictionary<string, object>;
    		
    		var login = new Login
    		{
    			Result = loginDictionary["result"] as string,
    			Details = loginDictionary["*"] as string,
    		};
    		
    		return new Warnings { Login = login };
    	}
    
    	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
