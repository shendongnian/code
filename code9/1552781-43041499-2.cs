    public class JsonContent : StringContent
    {
        private const string ApplicationJsonMediaType = "application/json";
        public JsonContent(object content) : base(SerializeContent(content), Encoding.UTF8, ApplicationJsonMediaType)
        {
        }
    
        private static string SerializeContent(object content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
