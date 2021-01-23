            string json = "{\'Id\':\'1\'}";
            var converter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(json, converter);
            IDictionary<string, object> dict = (IDictionary<string, object>)obj;
            foreach (string key in dict.Keys)
            {
                Console.WriteLine(key);
            }
