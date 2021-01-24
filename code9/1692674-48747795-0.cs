    public class CustomInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty reqProps = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            if(reqProps == null)
            {
                reqProps = new HttpRequestMessageProperty();
            }
                
            reqProps.Headers.Add("Custom-Header", "abcd");
            request.Properties[HttpRequestMessageProperty.Name] = reqProps;
            return null;
        }
    }
