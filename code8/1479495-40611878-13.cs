            [TypeConverter(typeof(FilterConverter))]
            public class FilterParams
            {
                public Dictionary<string, string> Filter { get; set; }
            }
            [HttpGet]
            public string Get(FilterParams filter)
            {
                var filterStatus = filter.Filter["status"]; 
            }
