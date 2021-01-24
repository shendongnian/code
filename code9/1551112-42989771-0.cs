    using System;
    using System.Reflection;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                CustomServer server = new CustomServer();
                server.Open();
    
                CustomClient client = new CustomClient();
                client.Connect();
    
                Console.WriteLine("Press Enter");
                Console.ReadLine();
    
                server.Close();
            }
        }
    
        [ServiceContract(CallbackContract = typeof(IBaseServiceCallback))]
        public interface IBaseService
        {
            [OperationContract]
            bool IsServiceInitiated();
        }
    
        public interface IBaseServiceCallback
        {
            [OperationContract]
            void TheCallback(string str);
        }
    
        //Change3
        //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true, AutomaticSessionShutdown = false, ConcurrencyMode = ConcurrencyMode.Multiple)]
        [CallbackBehavior]
        public class BaseServiceCallback : IBaseServiceCallback
        {
            public void TheCallback(string str)
            {
                Console.WriteLine(str);
            }
        }
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true, AutomaticSessionShutdown = false, ConcurrencyMode = ConcurrencyMode.Multiple)]
        public class BaseService : IBaseService
        {
            public bool IsServiceInitiated()
            {
                return true;
            }
        }
    
        public class CustomServer
        {
            private BaseService service;
            private ServiceHost host;
    
            public bool IsStarted
            {
                get { return host != null && host.State == CommunicationState.Opened; }
            }
    
            public CustomServer()
            {
                service = new BaseService();
                host = new ServiceHost(service, new Uri[] { new Uri("net.tcp://localhost:7780") });
    
                Type interfaceType = typeof(IBaseService);
    
                // Create service end point
                ServiceEndpoint endpointPipe = host.AddServiceEndpoint(interfaceType, new NetTcpBinding(), "CustomService");
    
                // Define TCP binding
                NetTcpBinding bindingPipe = (NetTcpBinding)endpointPipe.Binding;
    
                //Change1
                //bindingPipe.MaxReceivedMessageSize = long.MaxValue;
                //bindingPipe.MaxBufferPoolSize = long.MaxValue;
                //bindingPipe.MaxBufferSize = int.MaxValue;
    
                //bindingPipe.ReaderQuotas.MaxDepth = 2048;
                //bindingPipe.Security.Mode = SecurityMode.None;
                //bindingPipe.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
                //bindingPipe.Security.Message.ClientCredentialType = MessageCredentialType.None;
    
                // Increase MaxItemsInObjectGraph for all operations behaviors
                foreach (OperationDescription op in endpointPipe.Contract.Operations)
                {
                    var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
    
                    if (dataContractBehavior != null)
                    {
                        dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                    }
                }
    
                // In order to publish the service contract, it is important to publish the metadata
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                }
    
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    
                host.Description.Behaviors.Add(smb);
    
                // Add MEX endpoint
                host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:7780/IDMmex");
            }
    
            public void Open()
            {
                if (host != null)
                {
                    host.Open();
                }
            }
    
            public void Close()
            {
                if (host != null)
                {
                    host.Close();
                }
            }
        }
    
        public class CustomClient
        {
            private IBaseService serviceProxy;
            private BaseServiceCallback callback;
    
            public CustomClient()
            {
                callback = new BaseServiceCallback();
            }
    
            public void Connect()
            {
                string serviceUrl = "net.tcp://localhost:7780/CustomService";
    
                // Create a channel in order to find the exact call back type.
                DuplexChannelFactory<IBaseService> sampleChannel = new DuplexChannelFactory<IBaseService>(callback, new NetTcpBinding(), new EndpointAddress(serviceUrl));
    
                Type duplexChannelFactory = typeof(DuplexChannelFactory<>).MakeGenericType(new Type[] { typeof(IBaseService) });
    
                object pipeFactory = Activator.CreateInstance(duplexChannelFactory, new object[] { callback, new NetTcpBinding(), new EndpointAddress(serviceUrl) });
    
                // Get the service end point
                ServiceEndpoint endpoint = (ServiceEndpoint)duplexChannelFactory.GetProperty("Endpoint").GetValue(pipeFactory, null);
    
                // Configure TCP binding
                //NetTcpBinding tcpBinding = (NetTcpBinding)endpoint.Binding;
                //tcpBinding.MaxReceivedMessageSize = long.MaxValue;
                //tcpBinding.MaxBufferPoolSize = long.MaxValue;
                //tcpBinding.MaxBufferSize = int.MaxValue;
                //tcpBinding.ReaderQuotas.MaxDepth = 2048;
                //tcpBinding.Security.Mode = SecurityMode.None;
                //tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                //tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
                //tcpBinding.SendTimeout = TimeSpan.MaxValue;
                //tcpBinding.ReceiveTimeout = TimeSpan.MaxValue;
                //tcpBinding.OpenTimeout = TimeSpan.MaxValue;
                //tcpBinding.CloseTimeout = TimeSpan.MaxValue;
    
                // Increase MaxItemsInObjectGraph for all operations behaviors
                foreach (OperationDescription op in endpoint.Contract.Operations)
                {
                    var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
    
                    if (dataContractBehavior != null)
                    {
                        dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                    }
                }
    
                //serviceProxy = sampleChannel.CreateChannel();
    
                // Create the channel to retrieve the pipe proxy object
                MethodInfo method = duplexChannelFactory.GetMethod("CreateChannel", new Type[0]);
                object pipeProxyObject = method.Invoke(pipeFactory, new object[] { });
    
                // Set the service proxy with the retrieved pipe proxy object
                serviceProxy = (IBaseService)pipeProxyObject;
    
                //Change2
                ((IChannel)serviceProxy).Open();
    
                // FREEZE HERE...
                bool isServerInitiated = serviceProxy.IsServiceInitiated();
            }
        }
    }
