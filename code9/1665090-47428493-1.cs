    using Newtonsoft.Json;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                RootObject rootObject = new RootObject();
                string json = @"{ ""$and"": [ { ""$like"": { ""key"": ""name"", ""value"": ""foo"" } }, {""$gt"": { ""key"": ""price"", ""value"": 15 } } ] }  ";
                //var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                
    
                using (var reader = new JsonTextReader(new StringReader(json)))
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0} - {1} - {2}", reader.TokenType, reader.ValueType, reader.Value);
                        if (reader.TokenType.ToString() == "PropertyName")
                        {
                            //Console.WriteLine("Hi");
                            CreateConjunctionNode(reader, rootObject);
                            //CreateFilterNode(reader, rootObject);
                            //Console.WriteLine(reader.Value);
                        }
                    }
                }
            }
    
            private static void CreateFilterNode(JsonTextReader reader, RootObject rootObject)
            {
                if (reader.Value.ToString() == "$like")
                {
                    LikeNode likeNode = new LikeNode();
                }
                else if (reader.Value.ToString() == "$gt")
                {
                    GTNode gTNode = new GTNode();
                }
                else if (reader.Value.ToString() == "$lt")
                {
                    LTNode lTNode = new LTNode();
                }
                else if (reader.Value.ToString() == "$eq")
                {
                    EQNode eQNode = new EQNode();
                }
            }
    
            private static void CreateConjunctionNode(JsonTextReader reader, RootObject rootObject)
            {
                if (reader.Value.ToString() == "$and")
                {
                    rootObject.ConjunctionNode.Add(new AndNode());
                }
                else if (reader.Value.ToString() == "$or")
                {
                    rootObject.ConjunctionNode.Add(new OrNode());
                }
            }
        }
    }
