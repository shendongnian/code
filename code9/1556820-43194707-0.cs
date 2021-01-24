    using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;
                    using (Stream stream = client.OpenRead(url))
                    using (StreamReader streamReader = new StreamReader(stream))
                    using (JsonTextReader reader = new JsonTextReader(streamReader))
                    {
                        reader.SupportMultipleContent = true;
                        List<HoldingData> hd = new List<HoldingData>();
                        var serializer = new JsonSerializer();
                        while (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.StartObject)
                            {
                                HoldingData c = serializer.Deserialize<HoldingData>(reader);
                                hd.Add(c);
                            }
                        }
    
                        Console.ReadLine();
                    }
                }
