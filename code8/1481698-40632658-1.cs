    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
					
    public class Program
    {
	    public IEnumerable<string> GetPropertyKeysForDynamic(dynamic dynamicToGetPropertiesFor)
        {
            var attributesAsJObject = dynamicToGetPropertiesFor;
            var values = attributesAsJObject.ToObject<Dictionary<string, object>>();
            return values.Keys;
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
