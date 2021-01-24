    public class MyVarsConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<Dictionary<string, MyVar>>(reader);
            var myVars = new MyVars(dictionary);
            return myVars;
        }
        ...
    }
