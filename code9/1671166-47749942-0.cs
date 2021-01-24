    public class MyRoutine {
        public static void Main() {
             var client = new MyServiceClient();
             client.Endpoint.Behaviors.Add(new InspectorBehavior());
        }
    }
    public class InspectorBehavior : IEndpointBehavior {
        public void Validate(ServiceEndpoint endpoint) {
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            clientRuntime.MessageInspectors.Add(new MyMessageInspector());
        }
    }
    public class MyMessageInspector : IClientMessageInspector {
        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState) {
            reply = ChangeString(reply, from: "<paymentDate xsi:type=\"xsd:dateTime\"></paymentDate>", to: "<paymentDate xsi:nil=\"true\"></paymentDate>");
        }
         
        public static Message ChangeString(Message oldMessage, string from, string to) {
            var ms = new MemoryStream();
            var xw = XmlWriter.Create(ms);
            oldMessage.WriteMessage(xw);
            xw.Flush();
            var body = Encoding.UTF8.GetString(ms.ToArray());
            xw.Close();
            body = body.Replace(from, to);
            ms = new MemoryStream(Encoding.UTF8.GetBytes(body));
            var xdr = XmlDictionaryReader.CreateTextReader(ms, new XmlDictionaryReaderQuotas());
            var newMessage = Message.CreateMessage(xdr, int.MaxValue, oldMessage.Version);
            newMessage.Properties.CopyProperties(oldMessage.Properties);
            return newMessage;
        }
    }
