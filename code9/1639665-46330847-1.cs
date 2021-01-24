        static Dictionary<string, Type> _map = new Dictionary<string, Type>
        {
            { "person.created", typeof(PersonPayload)}
        }; // Add more entries here 
        public static WebhookPayload Deserialize(string json)
        {
            // 1. only parse once!
            var jobj = JObject.Parse(json); 
            // 2. get the c# type 
            var strType = jobj["type"].ToString(); 
            Type type;
            if (!_map.TryGetValue(strType, out type))
            {
                // Error! Unrecognized type
            }
            // 3. Now deserialize 
            var obj = (WebhookPayload) jobj.ToObject(type);
            return obj;
        }
