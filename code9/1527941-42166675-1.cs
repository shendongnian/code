    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    public class Program
    {
        public static void Main()
        {
            IDictionary<string,object> rptBusDetails = new ExpandoObject();
		    rptBusDetails["rptBusDetails"] = new List<object> 
		    {
			    new Dictionary<string, string>() {{"BusinessOwner", "Mark"}, {"ChartReq", ""}}, 
			    new Dictionary<string, string>() {{"BusinessOwner", "Tom"}, {"ChartReq", ""}}
		    };
            var parent = new object[] { rptBusDetails };
            foreach(var node in parent)
            {
                var details = JObject.FromObject(node);
			    foreach(var detail in details["rptBusDetails"])
			    {
				    string owner = detail["BusinessOwner"].Value<string>();
				    Console.WriteLine(owner);
			    }			
            }
        }
    }
