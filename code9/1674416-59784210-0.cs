    JObject jObject = JObject.Parse(jsonString);
            string displayName = (string)jObject.SelectToken("displayName");
            string type = (string)jObject.SelectToken("signInNames[0].type");
            string value = (string)jObject.SelectToken("signInNames[0].value");
            Console.WriteLine("{0}, {1}, {2}", displayName, type, value);
            JArray signInNames = (JArray)jObject.SelectToken("signInNames");
            foreach (JToken signInName in signInNames)
            {
                type = (string)signInName.SelectToken("type");
                value = (string)signInName.SelectToken("value");
                Console.WriteLine("{0}, {1}",  type, value);
            }
