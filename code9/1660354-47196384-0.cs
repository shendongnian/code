    namespace Example
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
    
        using Newtonsoft.Json;
    
        public class MyObject
        {
            [JsonProperty("data")]
            public Data Data { get; set; }
    
            [JsonProperty("success")]
            public bool Success { get; set; }
        }
    
        public class Data
        {
            [JsonProperty("order_reference")]
            public string OrderReference { get; set; }
    
            [JsonProperty("package_data")]
            public PackageDatum[] PackageData { get; set; }
        }
    
        public class PackageDatum
        {
            [JsonProperty("package_reference")]
            public string PackageReference { get; set; }
    
            [JsonProperty("tracking_no")]
            public string TrackingNo { get; set; }
        }
    }
