    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    dynamic result = JsonConvert.DeserializeObject<dynamic>(json);
        
    foreach (JProperty x in (JToken)result)
    {                
    	Console.WriteLine("{0}:{1}", x.Name, x.Value.ToString());            
    }
 
