    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace YourNamespace
    {
        public class MessageListenerBehavior : Attribute, IDispatchMessageInspector, IServiceBehavior
        {
            public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
            {
                return null;
            }
    
            public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                Message msg = reply.CreateBufferedCopy(int.MaxValue).CreateMessage();
    			try
    			{
    				//Setup StringWriter to use as input for our StreamWriter
    				//This is needed in order to capture the body of the message, because the body is streamed.
    				using (StringWriter stringWriter = new StringWriter())
    				using (XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter))
    				{
    					msg.WriteMessage(xmlTextWriter);
    					xmlTextWriter.Flush();
    					xmlTextWriter.Close();
    
    					string thexml = stringWriter.ToString();
    
    					XDocument doc = XDocument.Parse(thexml);
    					// alter the doc here...........
    					   Message newMsg = Message.CreateMessage(MessageVersion.Soap11, "http://..something", doc.ToString());
    				
    				reply = newMsg;
    			}
    			catch (Exception ex) { //handle it }
            }
    
            public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
    
            }
    
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
            {
                foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
                {
                    foreach (var endpoint in dispatcher.Endpoints)
                    {
                        endpoint.DispatchRuntime.MessageInspectors.Add(new MessageListenerBehavior());
                    }
                }
            }
    
            public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
            {
                //throw new NotImplementedException();
            }
        }
    
        public class WcfMessgeLoggerExtension : BehaviorExtensionElement
        {
            public override Type BehaviorType
            {
                get
                {
                    return typeof(MessageListenerBehavior);
                }
            }
    
            protected override object CreateBehavior()
            {
                return new MessageListenerBehavior();
            }
        }
    }
