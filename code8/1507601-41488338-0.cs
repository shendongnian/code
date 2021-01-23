    using System.Web.Script.Serialization;
    
    namespace ThirdPartyJSON
    {
        class Program
        {
            static void Main()
            {
                string jsonString = System.IO.File.ReadAllText("thirdparty.json");
    
                var serial = new JavaScriptSerializer();
    
                var o = serial.Deserialize<Rootobject>(jsonString);
            }
        }
    
        public class Rootobject
        {
            public int response { get; set; }
            public Sites sites { get; set; }
            public Records records { get; set; }
            public object[] referrals { get; set; }
            public int sucession { get; set; }
        }
    
        public class Sites
        {
            public object site { get; set; }
        }
    
        public class Site
        {
            public Customer[] customer { get; set; }
        }
    
        public class Customer
        {
            public Validation validation { get; set; }
        }
    
        public class Validation
        {
            public string customerdob { get; set; }
            public string customersurname { get; set; }
        }
    
        public class Records
        {
            public int insertcount { get; set; }
            public int deletecount { get; set; }
        }
    }
    
