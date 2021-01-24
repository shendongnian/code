        public void Convert()
        {
            dynamic myObj = JsonConvert.DeserializeObject(json);
            PrintObject(myObj, 0);
        }
        private void PrintObject(JToken token, int depth)
        {
            if (token is JProperty)
            {
                var jProp = (JProperty)token;
                var spacer = string.Join("", Enumerable.Range(0, depth).Select(_ => "\t"));
                var val = jProp.Value is JValue ? ((JValue)jProp.Value).Value : "-";
                Console.WriteLine($"{spacer}{jProp.Name}  -> {val}");
                foreach (var child in jProp.Children())
                {
                    PrintObject(child, depth + 1);
                }
            }
            else if (token is JObject)
            {
                foreach (var child in ((JObject)token).Children())
                {
                    PrintObject(child, depth + 1);
                }
            }
        }
