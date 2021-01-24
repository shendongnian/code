    public class JsonConverter
    {
        public static string ObjectToString(object o)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(o);
            return jsonString;
        }
        public static object StringToObject(string data)
        {
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.DeserializeObject(data);
        }
    }
