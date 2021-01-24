    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Data
    {
        public List<List<object>> AaData { get; set; }
    }    
    
    public class Program
    {
    	public static void Main()
    	{
    		var json = ""; // your json here
    		var m = JsonConvert.DeserializeObject<Data>(json);
    		Console.WriteLine(m.AaData[0][0]);
    		Console.WriteLine(m.AaData[1][2]);
    	}
    }
