        [ServiceContract]
        public interface IServiceJsonContract
        {
            [WebInvoke(UriTemplate = "/MyMethod", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
            Stream MyMethod(Message input);
        }
    
    Stream MyMethod(Message input)
    {
    ..
    return new MemoryStream(Encoding.UTF8.GetBytes("{\"bla\": 2 }"));
    }
