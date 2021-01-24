        private static void ChangePropertiesToLowerCase(JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties().ToList())
            {
                if(property.Value.Type == JTokenType.Object)// replace property names in child object
                    ChangePropertiesToLowerCase((JObject)property.Value);
                property.Replace(new JProperty(property.Name.ToLower(),property.Value));// properties are read-only, so we have to replace them
            }
        }
