    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace ConsoleTest
    {
        class Program
        {
            [DataContract]
            public class Example
            {
                [DataMember]
                public Product Product { get; set; }
            }
    
            [DataContract]
            public class Product
            {
                [DataMember]
                public int Id { get; set; }
                [DataMember]
                public string Name { get; set; }
            }
    
            static void Main(string[] args)
            {
                var json = @"
                                [
                                    {
                                        ""product"": {
                                            ""id"": 2,
                                            ""name"": ""Auto""
                                        }
                                    }
                                ]";
    
                var obj = JsonConvert.DeserializeObject<List<Example>>(json,
                                                             new JsonSerializerSettings
                                                             {
                                                                 ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                             });
            }
        }
    }
