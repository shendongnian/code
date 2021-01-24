        [XmlRoot(ElementName= "UpdateSale", Namespace="http://tokenws.netgen.co.za/")]
        public class Sale
        {
        }
        [XmlRoot(ElementName= "netCredentials")]
        public class NetCredentials
        {
            [XmlElement(ElementName="UserName",Namespace="http://tempuri.org/")]
            public Name userName { get; set;} 
            [XmlElement(ElementName="Password",Namespace="http://tempuri.org/")]
            public Name password { get; set;} 
        }
        public class Name
        {
            [XmlText]
            public string name { get; set;}
        }
