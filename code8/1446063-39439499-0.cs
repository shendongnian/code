        static void Main(string[] args)
        {
            // our fake huge object
            var json = @"{""root"":{""items"":[{""data"":""value""},{""data"":""value""}]}}";
            using (var reader = new JsonTextReader(new StringReader(json))) {
                bool insideItems = false;
                while (reader.Read()) {
                    // reading tokens one by one
                    if (reader.TokenType == JsonToken.PropertyName) {
                        // remember, this is just an example, so it's quite crude
                        if ((string) reader.Value == "items") {
                            // we reached property named "items" of some object. We assume this is "items" of our root object
                            insideItems = true;
                        }
                    }
                    if (reader.TokenType == JsonToken.StartObject && insideItems) {
                        // if we reached start of some json object, and we have already reached "items" property before - we assume
                        // we are inside "items" array
                        // here, deserialize items one by one. This way you will consume almost no memory at any given time
                        var item = JsonSerializer.Create().Deserialize<DataItem>(reader);
                        Console.WriteLine(item.Data);
                    }                    
                }
            }
        }
        public class DataItem {
            public string Data { get; set; }
        }
    }
