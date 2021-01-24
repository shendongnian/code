     using (var sr = File.OpenText(@"C:\Users\sranade\documents\visual studio 2015\Projects\AccessModifiers\AccessModifiers\sample.json"))
            {
                var o = (JArray)JToken.ReadFrom(new JsonTextReader(sr));
                foreach (var obj in o.Children<JObject>())
                {
                    foreach (var p in obj.Properties())
                    {
                        if (p.Name.Contains("message") && p.Value.ToString().Contains("photo"))
                        {
                            Console.WriteLine(p.Value.ToString());
                        }
                    }
                }
            }
