    void Main()
    {
    	string email = "davidizhakinew@gmail.com";
    	var postback = new Postback { email = email };
    
    	Console.WriteLine(new JavaScriptSerializer().Deserialize("{ email : '" + email + "' }",
             typeof(Postback))); // email string escaped, ok
    	Console.WriteLine(new JavaScriptSerializer().Deserialize("{ email : " + email + " }",
             typeof(Postback))); // YOUR INPUT, exception Invalid JSON primitive
    }
    
    public class Postback
    {
    	public string email { get; set; }
    }
