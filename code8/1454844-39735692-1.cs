    class Program
    {
        static void Main(string[] args)
        {
            var item = @"
                {
                    ""Filename"":""mypage.html"",
                    ""Info"":{
                        ""title"":{
                            ""Name"":""title"",
                            ""Values"":[""This is title""],
                            ""NumericValues"":[],
                            ""DateTimeValues"":[],
                            ""LinkedComponentValues"":[],
                            ""FieldType"":0
                        }
                    },
                    ""Id"":""123"",
                    ""Title"":""This is my page""
                }";
    
            var description = @"{
                    ""Name"":""description"",
                    ""Values"":[""This is description""],
                    ""NumericValues"":[],
                    ""DateTimeValues"":[],
                    ""LinkedComponentValues"":[],
                    ""FieldType"":0}";
    
            var itemJObj = JObject.Parse(item);
            var descriptionJObj = JObject.Parse(description);
    
            var titleJObj = itemJObj["Info"] as JObject;
            titleJObj.Add("description", descriptionJObj);
    
            var serializer = new JsonSerializer{ContractResolver = new CamelCasePropertyNamesContractResolver()};
            var json = JObject.FromObject(itemJObj, serializer);
    
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
