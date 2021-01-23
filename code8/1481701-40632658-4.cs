	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
					
	public class Program
	{
		public void Main()
    	{
			var r = new Random();
    		dynamic j = JsonConvert.DeserializeObject(string.Format(@"{{""{0}"":""hard"", ""easyField"":""yes""}}", r.Next()));
		
			foreach(var property in j.ToObject<Dictionary<string, object>>())
        	{
				Console.WriteLine(property.Key + " " + property.Value);
        	}
    	}
	}
