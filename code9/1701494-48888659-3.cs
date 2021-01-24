    void Main()
    {
    	string email = "davidizhakinew@gmail.com";
    	var postback = new Postback { email = email };
    
    	Console.WriteLine(new JavaScriptSerializer().Deserialize<Postback>("{ email : '" + email + "' }")); // email string escaped, ok
    	Console.WriteLine(new JavaScriptSerializer().Deserialize<Postback>("{ email : " + email + " }")); // YOUR INPUT, exception Invalid JSON primitive
    }
    
    public class Postback
    {
    	public string email { get; set; }
    }
