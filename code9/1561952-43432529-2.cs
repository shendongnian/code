    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    namespace CustomServiceLibrary
    {
        class Server
        {
            private readonly ushort port;
            private readonly Service1 Service1;
            private NetTcpBinding netTcpBinding;
            private ServiceHost serviceHost;
            public Server(ushort port)
            {
                this.port = port;
                Service1 = new Service1();
            }
            public void Start()
            {
                try
                {
                    CreateServiceHost();
                    CreateBinding();
                    AddEndpoint();
                    serviceHost.Open();
                    Console.WriteLine("Service has been opended");
                    ConfigureHTTP();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR      := {ex.Message}");
                    Console.WriteLine($"StackTrace := {ex.StackTrace}");
                }
            }
            private void AddEndpoint()
            {
                serviceHost.AddServiceEndpoint(typeof(IService1), netTcpBinding, string.Format("{1}://0.0.0.0:{0}/", port, "net.tcp"));
            }
            private void ConfigureHTTP()
            {
                var serviceBehavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (serviceBehavior == null) return;
                serviceBehavior.HttpGetEnabled = false;
                serviceBehavior.HttpsGetEnabled = false;
            }
            private void CreateBinding()
            {
                netTcpBinding = new NetTcpBinding
                {
                    MaxReceivedMessageSize = int.MaxValue,
                    MaxBufferPoolSize = int.MaxValue,
                    Security = new NetTcpSecurity
                    {
                        Mode = SecurityMode.None,
                        Transport = new TcpTransportSecurity()
                    }
                };
            }
            private void CreateServiceHost()
            {
                serviceHost = new ServiceHost(Service1);
            }
        }
    }
