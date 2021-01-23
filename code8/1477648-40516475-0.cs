    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using System.Xml;
    
    namespace MyProj
    {
        public class CustomInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                return null;
            }
    
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                if (reply.Headers.Action == "urn:example:wsdl/Adapter/getUserResponse")
                {
                    MessageBuffer copy = reply.CreateBufferedCopy(int.MaxValue);
                    XmlDictionaryReader xdr = copy.CreateMessage().GetReaderAtBodyContents();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xdr);
                    xdr.Close();
    
                    doc.InnerXml = doc.InnerXml.Replace(@"<myprop>",
                        @"<myprop xsi:type=""ns1:MapType"" xmlns:ns1=""urn:example.com:types"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">");
                    doc.InnerXml = doc.InnerXml.Replace(@"<item>", @"<item xmlns=""urn:example.com:types"">");
    
                    MemoryStream ms = new MemoryStream();
                    XmlWriter xw = XmlWriter.Create(ms);
                    doc.Save(xw);
                    xw.Flush();
                    xw.Close();
                    ms.Position = 0;
                    XmlReader reader = XmlReader.Create(ms);
    
    
                    Message newMsg = Message.CreateMessage(reply.Version, reply.Headers.Action, reader);
                    reply = newMsg;
                }
    
            }
        }
    }
