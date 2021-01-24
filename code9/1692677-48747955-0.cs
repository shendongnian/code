    public class ClientMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty property = new HttpRequestMessageProperty();
            property.Headers["User-Agent"] = "value";
            request.Properties.Add(HttpRequestMessageProperty.Name, property);
            return null;
        }
    ...
    }
