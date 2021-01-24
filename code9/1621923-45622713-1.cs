    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleTest
    {
        class Program
        {
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
    
                dynamic list = JsonConvert.DeserializeObject<List<dynamic>>(json);
                var id = (int)list[0].product.id;
            }
        }
    }
