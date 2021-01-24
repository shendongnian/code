    using System.IO;
    using System.Xml.Serialization;
    
    namespace WpfApp2
    {
        internal class Test
        {
            private readonly string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    
    <Request>
      <AccountStage att1=""419749"" att2=""575474"" att3=""800177"" att4=""096057"" att5=""917185"" att6=""017585"" att7=""huKuBgcQ""
                    att8=""stgs10"" att9=""ACTIVE"" att10=""2"" att11=""2"" />
    </Request>";
    
            public Test()
            {
                Request request;
    
                // serialize
                var serializer = new XmlSerializer(typeof(Request));
                using (var reader = new StringReader(xml))
                {
                    request = (Request) serializer.Deserialize(reader);
                }
    
                // deserialize
    
                request.AccountStage.Attribute1 = "abcd";
    
                using (var writer = new StringWriter())
                {
                    serializer.Serialize(writer, request);
                    var s = writer.ToString();
                }
            }
        }
    
        public class Request
        {
            public AccountStage AccountStage { get; set; }
        }
    
        public class AccountStage
        {
            [XmlAttribute("att1")]
            public string Attribute1 { get; set; }
        }
    }
