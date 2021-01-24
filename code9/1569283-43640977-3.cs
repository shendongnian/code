    public class Post_4cfd1cd6_a038_420d_8cb5_ec5a2628df1a
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
        }
        public class Service : ITest
        {
            public string Echo(string text)
            {
                Console.WriteLine("In service, text = {0}", ReplaceControl(text));
                return text;
            }
        }
        static Binding GetBinding()
        {
            //var result = new WSHttpBinding(SecurityMode.None) { MessageEncoding = WSMessageEncoding.Text };
            var result = new BasicHttpBinding() { MessageEncoding = WSMessageEncoding.Mtom };
            return result;
        }
        static string ReplaceControl(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in text)
            {
                if ((' ' <= c && c <= '~') && c != '\\')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.AppendFormat("\\u{0:X4}", (int)c);
                }
            }
    
            return sb.ToString();
        }
        public class MyInspector : IEndpointBehavior, IDispatchMessageInspector, IClientMessageInspector
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.MessageInspectors.Add(this);
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
            }
    
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                request = request.CreateBufferedCopy(int.MaxValue).CreateMessage();
                return null;
            }
    
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
            }
    
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                reply = reply.CreateBufferedCopy(int.MaxValue).CreateMessage();
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                return null;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(ITest), GetBinding(), "");
            endpoint.Behaviors.Add(new MyInspector());
            host.Open();
            Console.WriteLine("Host opened");
    
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(GetBinding(), new EndpointAddress(baseAddress));
            factory.Endpoint.Behaviors.Add(new MyInspector());
            ITest proxy = factory.CreateChannel();
    
            string input = "\t\tDoc1\tCase1\tActive";
            string output = proxy.Echo(input);
            Console.WriteLine("Input = {0}, Output = {1}", ReplaceControl(input), ReplaceControl(output));
            Console.WriteLine("input == output: {0}", input == output);
    
            ((IClientChannel)proxy).Close();
            factory.Close();
    
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
