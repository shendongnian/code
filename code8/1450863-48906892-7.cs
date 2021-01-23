    void Main()
    {
    	string json = @"{ ""warnings"": { ""login"": { result: ""OK"", ""*"": ""blah blah blah"" } } }";
    
    	var js = new JavaScriptSerializer();
    	js.RegisterConverters(new List<JavaScriptConverter> { new ResultConverter() });
    	var result = js.Deserialize<Warnings>(json);
    	Console.WriteLine(result);
    }
    public class Login
    {
    	public string Result { get; set; }
    	public string Details { get; set; }
    }
    
    public class Warnings
    {
    	public Login Login { get; set; }
    }
