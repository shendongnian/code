    using System;
	using Newtonsoft.Json;
	using System.ComponentModel;
					
	public class Program
	{
		
		public static void Main()
		{
			var user = new User();
		
			user.UserID = "1234";
			user.ssn = "";
		
			var settings = new JsonSerializerSettings();
		
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.Ignore;
		
		
			Console.WriteLine(JsonConvert.SerializeObject(user, settings));
		}
	}
	public class User
	{
		[DefaultValue("")]
		public string UserID { get; set; }
	
		[DefaultValue("")]
    	public string ssn { get; set; }
	
		[DefaultValue("")]
    	public string empID { get; set; }
    
		[DefaultValue("")]
    	public string schemaAgencyName { get; set; }
    
		[DefaultValue("")]
    	public string givenName { get; set; }
    
		[DefaultValue("")]
    	public string familyName { get; set; }
    
		[DefaultValue("")]
    	public string password { get; set; }
	}
