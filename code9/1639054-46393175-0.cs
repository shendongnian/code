    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Opc.Ua;
    using Opc.Ua.Client;
    using System.Security.Cryptography.X509Certificates;
    namespace NetCoreConsoleClient
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(".Net Core OPC UA Console Client sample");
                string endpointURL;
                if (args.Length == 0)
                {
                    // use OPC UA .Net Sample server 
                    endpointURL = "opc.tcp://" + Utils.GetHostName() + ":48010"; // UaCPPServer
                }
                else
                {
                    endpointURL = args[0];
                }
                try
                {
                    Task t = ConsoleSampleClient(endpointURL);
                    t.Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exit due to Exception: {0}", e.Message);
                }
            }
    
            public static async Task ConsoleSampleClient(string endpointURL)
            {
                Console.WriteLine("1 - Create an Application Configuration.");
                Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);
                var config = new ApplicationConfiguration()
                {
                    ApplicationName = "UA Core Sample Client",
                    ApplicationType = ApplicationType.Client,
                    ApplicationUri = "urn:" + Utils.GetHostName() + ":OPCFoundation:CoreSampleClient",
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier
                        {
                            StoreType = "X509Store",
                            StorePath = "CurrentUser\\UA_MachineDefault",
                            SubjectName = "UA Core Sample Client"
                        },
                        TrustedPeerCertificates = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = "OPC Foundation/CertificateStores/UA Applications",
                        },
                        TrustedIssuerCertificates = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = "OPC Foundation/CertificateStores/UA Certificate Authorities",
                        },
                        RejectedCertificateStore = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = "OPC Foundation/CertificateStores/RejectedCertificates",
                        },
                        NonceLength = 32,
                        AutoAcceptUntrustedCertificates = true
                    },
                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
                };
    
                await config.Validate(ApplicationType.Client);
    
                bool haveAppCertificate = config.SecurityConfiguration.ApplicationCertificate.Certificate != null;
    
                if (!haveAppCertificate)
                {
                    Console.WriteLine("    INFO: Creating new application certificate: {0}", config.ApplicationName);
    
                    X509Certificate2 certificate = CertificateFactory.CreateCertificate(
                        config.SecurityConfiguration.ApplicationCertificate.StoreType,
                        config.SecurityConfiguration.ApplicationCertificate.StorePath,
                        null,
                        config.ApplicationUri,
                        config.ApplicationName,
                        config.SecurityConfiguration.ApplicationCertificate.SubjectName,
                        null,
                        CertificateFactory.defaultKeySize,
                        DateTime.UtcNow - TimeSpan.FromDays(1),
                        CertificateFactory.defaultLifeTime,
                        CertificateFactory.defaultHashSize,
                        false,
                        null,
                        null
                        );
    
                    config.SecurityConfiguration.ApplicationCertificate.Certificate = certificate;
    
                }
    
                haveAppCertificate = config.SecurityConfiguration.ApplicationCertificate.Certificate != null;
    
                if (haveAppCertificate)
                {
                    config.ApplicationUri = Utils.GetApplicationUriFromCertificate(config.SecurityConfiguration.ApplicationCertificate.Certificate);
    
                    if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
                    {
                        config.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
                    }
                }
                else
                {
                    Console.WriteLine("    WARN: missing application certificate, using unsecure connection.");
                }
    
                Console.WriteLine("2 - Discover endpoints of {0}.", endpointURL);
                var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpointURL, haveAppCertificate);
                Console.WriteLine("    Selected endpoint uses: {0}",
                    selectedEndpoint.SecurityPolicyUri.Substring(selectedEndpoint.SecurityPolicyUri.LastIndexOf('#') + 1));
    
                Console.WriteLine("3 - Create a session with OPC UA server.");
                var endpointConfiguration = EndpointConfiguration.Create(config);
                var endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);
                var session = await Session.Create(config, endpoint, false, ".Net Core OPC UA Console Client", 60000, new UserIdentity(new AnonymousIdentityToken()), null);
    
    
                Console.WriteLine("4 - Call VectorAdd method with structure arguments.");
                EncodeableFactory.GlobalFactory.AddEncodeableType(typeof(Vector));
                var v1 = new Vector { X = 1.0, Y = 2.0, Z = 3.0 };
                var v2 = new Vector { X = 1.0, Y = 2.0, Z = 3.0 };
                var outArgs = session.Call(NodeId.Parse("ns=2;Demo.Method"), NodeId.Parse("ns=2;s=Demo.Method.VectorAdd"), new ExtensionObject(v1), new ExtensionObject(v2) );
                var result = ExtensionObject.ToEncodeable((ExtensionObject)outArgs[0]) as Vector;
    
                Console.WriteLine($"  {v1}");
                Console.WriteLine($"+ {v2}");
                Console.WriteLine(@"  ------------------");
                Console.WriteLine($"  {result}");
    
                Console.WriteLine("8 - Press any key to exit...");
                Console.ReadKey(true);
            }
    
            private static void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
            {
                Console.WriteLine("Accepted Certificate: {0}", e.Certificate.Subject);
                e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
            }
    
            public class Vector : EncodeableObject
            {
                public double X { get; set; }
    
                public double Y { get; set; }
    
                public double Z { get; set; }
    
                public override ExpandedNodeId TypeId => ExpandedNodeId.Parse("nsu=http://www.unifiedautomation.com/DemoServer/;i=3002");
    
                public override ExpandedNodeId BinaryEncodingId => ExpandedNodeId.Parse("nsu=http://www.unifiedautomation.com/DemoServer/;i=5054");
    
                public override ExpandedNodeId XmlEncodingId => NodeId.Null;
    
                public override void Encode(IEncoder encoder)
                {
                    encoder.WriteDouble("X", this.X);
                    encoder.WriteDouble("Y", this.Y);
                    encoder.WriteDouble("Z", this.Z);
                }
    
                public override void Decode(IDecoder decoder)
                {
                    this.X = decoder.ReadDouble("X");
                    this.Y = decoder.ReadDouble("Y");
                    this.Z = decoder.ReadDouble("Z");
                }
    
                public override string ToString() => $"{{ X={this.X}; Y={this.Y}; Z={this.Z}; }}";
            }
        }
    }
