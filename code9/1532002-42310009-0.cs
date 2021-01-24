    public class HttpStatusCodeMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                var httpResponseProperty = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                Console.WriteLine($"Response status is {(int)httpResponseProperty.StatusCode}");
            }
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    }
