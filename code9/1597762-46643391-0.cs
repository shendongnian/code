    public class CustomMessageHeader : MessageHeader
            {
                private const string NAMESPACE_SECURITY = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
                public CustomMessageHeader()
                {
                }
                public override string Name
                {
                    get { return "wsse:Security"; }
                }
                public override string Namespace
                {
                    get { return ""; }
                }
                protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
                {
                    writer.WriteAttributeString("xmlns", "wsse", null, NAMESPACE_SECURITY);
                    writer.WriteStartElement("wsse:UsernameToken");
                    writer.WriteElementString("wsse:Username", "YOUR_USERNAME");
                    writer.WriteElementString("wsse:Password", "YOUR_PASSWORD");
                    writer.WriteEndElement();
                }
            }
    public class ClientMessageInspector : IClientMessageInspector
            {
                public object BeforeSendRequest(ref Message request, IClientChannel channel)
                {
                    CustomMessageHeader header = new CustomMessageHeader();
                    request.Headers.RemoveAt(0);
                    request.Headers.Add(header);
                    return request;
                }
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                }
            }
    public class CustomEndpointBehavior : IEndpointBehavior
            {
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
                {
                    clientRuntime.ClientMessageInspectors.Add(new ClientMessageInspector());
                }
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
                {
                }
    
                public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
                {
                }
    
                public void Validate(ServiceEndpoint endpoint)
                {
                }
    }
