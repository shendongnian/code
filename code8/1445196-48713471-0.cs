    public static byte[] DynamicToByteArray(object message)
        {
            string serializeObject = JsonConvert.SerializeObject(message);
            byte[] bytes = Encoding.UTF8.GetBytes(serializeObject);
            return bytes;
        }
