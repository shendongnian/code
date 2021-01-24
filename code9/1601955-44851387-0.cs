    public class JsonHelper
    {
        public static XmlDocument ConvertToXml(string json)
        {
            JToken token = JToken.Parse(json);
            // Change "blank" to whatever you want the replacement name to be.
            ReplaceEmptyPropertyNames(token, "blank");
            return JsonConvert.DeserializeXmlNode(token.ToString());
        }
        public static void ReplaceEmptyPropertyNames(JToken token, string replaceWithName)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (JProperty prop in token.Children<JProperty>().ToList())
                {
                    if (prop.Name == string.Empty)
                    {
                        prop.AddAfterSelf(new JProperty(replaceWithName, prop.Value));
                        prop.Remove();
                    }
                    ReplaceEmptyPropertyNames(prop.Value, replaceWithName);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken child in token.Children())
                {
                    ReplaceEmptyPropertyNames(child, replaceWithName);
                }
            }
        }
    }
