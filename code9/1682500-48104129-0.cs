    using System;
    using Newtonsoft.Json.Linq;
    public class Program
    {
    	public static void Main()
    	{
    		var str = "[{\"CAT\":\"OK\",\"MSG\":\"SESION-OK\",\"EXTRA\":{\"ID\":\"3\",\"NOM\":\"CHARLS\"}}]";
    		var j = JArray.Parse(str);
    		var token = j[0];
            //using dynamic to simplify sample, create/use your own type
    		var obj = token.ToObject<dynamic>(); 
   		
            Console.WriteLine(obj.CAT);
    		Console.WriteLine(obj.MSG);
    		Console.WriteLine(obj.EXTRA);
    		Console.WriteLine(obj.EXTRA.ID);
    		Console.WriteLine(obj.EXTRA.NOM);
    	}
    }
