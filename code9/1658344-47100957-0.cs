    public static class ResponseDeserializer
    {
        public static Response Deserialize(string psMessage, string psResponeItems)
        {
            dynamic loMessage = JsonConvert.DeserializeObject(psMessage);
    
            return new Response()
            {
                Message = loMessage.message,
                ResponseItems = JsonConvert.DeserializeObject<List<ResponseItem>>(psResponeItems)
            };
        }
    }
