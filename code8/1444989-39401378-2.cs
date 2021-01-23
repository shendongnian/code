    namespace Stackoverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int objBusinessHeader = 1,
                objSecurityHeader = 2,
                objManifestHeader = 3,
                objFormData = 4;
    
                var obj = (IService)RetrieveRequestObject(2010, objBusinessHeader,
                    objSecurityHeader,
                    objManifestHeader,
                    objFormData);
    
                Console.WriteLine(obj.GetValues());
    
    
                var obj2 = (IService)RetrieveRequestObject(2011, objBusinessHeader,
                    objSecurityHeader,
                    objManifestHeader,
                    objFormData);
    
                Console.WriteLine(obj2.GetValues());
    
                Console.ReadKey();
            }
    
            private static object RetrieveRequestObject(int taxYear, object objBusinessHeader,
                object objSecurityHeader, object objManifestHeader, object objFormData)
            {
                var serviceInstance = Activator.CreateInstance("Stackoverflow",
                    "Stackoverflow.Service" + taxYear).Unwrap();
    
                var serviceInstanceType = serviceInstance.GetType();
    
                var aCABusinessHeaderInfo = serviceInstanceType.GetProperty("ACABusinessHeader");
                var securityInfo = serviceInstanceType.GetProperty("Security");
                var aCATransmitterManifestReqDtlInfo = serviceInstanceType.GetProperty("ACATransmitterManifestReqDtl");
                var aCABulkRequestTransmitterInfo = serviceInstanceType.GetProperty("ACABulkRequestTransmitter");
    
                aCABusinessHeaderInfo.SetValue(serviceInstance, objBusinessHeader, null);
                securityInfo.SetValue(serviceInstance, objSecurityHeader, null);
                aCATransmitterManifestReqDtlInfo.SetValue(serviceInstance, objManifestHeader, null);
                aCABulkRequestTransmitterInfo.SetValue(serviceInstance, objFormData, null);
    
                return serviceInstance;
            }
        }
    
        interface IService
        {
            string GetValues();
        }
    
        class Service2011 : IService
        {
            public int ACABusinessHeader { get; set; }
            public int Security { get; set; }
            public int ACATransmitterManifestReqDtl { get; set; }
            public int ACABulkRequestTransmitter { get; set; }
    
            public string GetValues()
            {
                return $@"Service 2011 - {ACABusinessHeader} {Security} {ACATransmitterManifestReqDtl}
                    {ACABulkRequestTransmitter}";
            }
        }
    
        class Service2010 : IService
        {
            public int ACABusinessHeader { get; set; }
            public int Security { get; set; }
            public int ACATransmitterManifestReqDtl { get; set; }
            public int ACABulkRequestTransmitter { get; set; }
    
            public string GetValues()
            {
                return $@"Service 2010 - {ACABusinessHeader} {Security} {ACATransmitterManifestReqDtl}
                    {ACABulkRequestTransmitter}";
            }
        }
    }
