    public class CustomInspectorBehavior : IClientMessageInspector
    {
        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            UriBuilder builder = new UriBuilder(channel.RemoteAddress.ToString());
            builder.Path += "?" + ((HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name]).QueryString;
            request.Headers.To = builder.Uri;
            return null;
        }
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
 
