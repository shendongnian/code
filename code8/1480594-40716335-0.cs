    class Program
    {
        static void Main(string[] args)
        {
            // Hard-coded LogOn method 
            // Reference: Ice.Core.Session.dll
            Ice.Core.Session session = new Ice.Core.Session("manager", "manager", "net.tcp://AppServer/MyCustomerAppserver-99999-10.0.700.2");
 
            // References: Epicor.ServiceModel.dll, Erp.Contracts.BO.ABCCode.dll
            var abcCodeBO = Ice.Lib.Framework.WCFServiceSupport.CreateImpl<Erp.Proxy.BO.ABCCodeImpl>(session, Erp.Proxy.BO.ABCCodeImpl.UriPath);
 
            // Call the BO methods
            var ds = abcCodeBO.GetByID("A");
            var row = ds.ABCCode[0];
 
            System.Console.WriteLine("CountFreq is {0}", row.CountFreq);
            System.Console.WriteLine("CustomField_c is {0}", row["CustomField_c"]);
            System.Console.ReadKey();
        }
    }
