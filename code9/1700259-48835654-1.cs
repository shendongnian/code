    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ClassLibrary1
    {
        public class Class1
        {
            public class Product
            {
                public string id { get; set; }
                public string name { get; set; }
                public bool inactive { get; set; }
            }
    
            public void testingClass()
            {
                string testJSONResponse = @"
        [{
                    ""id"": ""1"",
            ""name"": ""test"",
            ""inactive"": false
        },]
    ";
                var myNewCSharpObject = JsonConvert.DeserializeObject<Product[]>(testJSONResponse);
    
            }
        }
    }
