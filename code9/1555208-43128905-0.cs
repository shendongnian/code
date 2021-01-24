    using System;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    var jObject = JObject.Parse(json)["RESULTS"]; 
    var result = jObject.Select(x => x.First["DDR_ID"]).Values<int>();
