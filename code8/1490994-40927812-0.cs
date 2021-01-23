    public class CustomJSONSerializationHelper
    {
        public string CustomSerialize(Dictionary<AuthorizationKey, ConditionalActionFlags> actionFlagMappings)
        {
            // ToArray() and use custom convertors, because NewtonSoft JSON can't handle dictionary key values and struct.
            var jsonString = JsonConvert.SerializeObject(actionFlagMappings.ToArray(), new Newtonsoft.Json.Converters.StringEnumConverter(), new AuthorizationKeyJsonConverter());
            return jsonString;
        }
        public Dictionary<AuthorizationKey, ConditionalActionFlags> CustomDeserialize(string jsonActionFlagMappings)
        {
            var resultArray = CustomDeserializeOverLoad(jsonActionFlagMappings);
            return (resultArray != null) ? resultArray.ToList().ToDictionary(pair => pair.Key, pair => pair.Value) : null;
        }
        public KeyValuePair<AuthorizationKey, ConditionalActionFlags>[] CustomDeserializeOverLoad(string jsonActionFlagMappings)
        {
            var result = JsonConvert.DeserializeObject<KeyValuePair<AuthorizationKey, ConditionalActionFlags>[]>(jsonActionFlagMappings,
                 new Newtonsoft.Json.Converters.StringEnumConverter(), new AuthorizationKeyJsonConverter());
            return result;
        }
    }
