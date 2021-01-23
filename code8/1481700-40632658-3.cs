    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
					
    public class Program
    {
	    public IEnumerable<string> GetPropertyKeysForDynamic(dynamic jObject)
        {
            return jObject.ToObject<Dictionary<string, object>>().Keys;
        }
	    public void Main()
        {
		    var r = new Random();
    	    dynamic j = JsonConvert.DeserializeObject(string.Format(@"{{""{0}"":""hard"", ""easyField"":""yes""}}", r.Next()));
		
		    foreach(string property in GetPropertyKeysForDynamic(j))
            {
				Console.WriteLine(property);
				Console.WriteLine(j[property]);
            }
        }
    }
