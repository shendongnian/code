    public class JsonExtensions
    {
        /// <summary>
        /// Deeply flattens a json object to a dictionary.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        /// <returns>The flattened json in dictionary kvp.</returns>
        public static Dictionary<string, object> DeepFlatten(string jsonStr)
        {
            var dict = new Dictionary<string, object>();
            var token = JToken.Parse(jsonStr);
            FillDictionaryFromJToken(dict, token, String.Empty);
            return dict;
        }
    
        private static void FillDictionaryFromJToken(Dictionary<string, object> dict, JToken token, string prefix)
        {
            if(token.Type == JTokenType.Object)
            {
                foreach (var property in token.Children<JProperty>())
                {
                    FillDictionaryFromJToken(dict, property.Value, property.Name);
                    // Uncomment and replace if you'd like prefixed index
                    // FillDictionaryFromJToken(dict, value, Prefix(prefix, property.Name));
                }
            }
            else if(token.Type == JTokenType.Array)
            {
                var idx = 0;
                foreach (var value in token.Children())
                {
                    FillDictionaryFromJToken(dict, value, String.Empty);
                    idx++;
                    // Uncomment and replace if you'd like prefixed index
                    // FillDictionaryFromJToken(dict, value, Prefix(prefix, idx.ToString()));
                }
            }
            else // The base case
            {
                dict[prefix] = ((JValue)token).Value; // WARNING: will ignore duplicate keys if you don't use prefixing!!!
            }
        }
    
        private static string Prefix(string prefix, string tokenName)
        {
            return String.IsNullOrEmpty(prefix) ? tokenName : $"{prefix}.{tokenName}";
        }
    
    }
