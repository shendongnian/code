    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Test();
            }
        }
        public class Test
        {
            const string FILENAME = @"c:\temp\test2.xml";
            public Test()
            {
                StreamReader reader = new StreamReader(FILENAME, Encoding.UTF8);
                GetWebServiceResultFromStream(reader);
            }
            private Envelope GetWebServiceResultFromStream(StreamReader str)
            {
                bool b = true;
                Envelope xmlResponse = null;
                String xmlPayload = "";
               //Deserialize our XML
                try
                {
                    //System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                    //using (Stream savestream = str.BaseStream)
                    //{
                    //    xmlResponse = (Envelope)soapFormatter.Deserialize(savestream);
                    //}
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(Envelope));
                    using (Stream savestream = str.BaseStream)
                    {
                        StreamReader streamreader = new StreamReader(savestream, Encoding.UTF8);
                        xmlPayload = streamreader.ReadToEnd();
                        //xmlPayload = System.Security.SecurityElement.Escape(xmlPayload);
                        //xmlPayload = xmlPayload.Replace("&amp;", "&");
                        //xmlPayload = xmlPayload.Replace("&", "&amp;");
                        xmlPayload = xmlPayload.Replace("'", "&apos;");
                        //xmlPayload = xmlPayload.Replace("soap:Envelope", "Envelope");
                        File.WriteAllText(@"myxml.xml",xmlPayload);
                        byte[] byteArray = Encoding.UTF8.GetBytes(xmlPayload);
                        MemoryStream secondstream = new MemoryStream(byteArray);
                        secondstream.Position = 0;
                        xmlResponse = sr.Deserialize(secondstream) as Envelope;
                        //xmlResponse = (Envelope)DeserializeFromXml<Envelope>(xmlPayload);
                        //XmlDocument doc = new XmlDocument();
                        //doc.Load(secondstream);
                        //XmlNodeReader reader = new XmlNodeReader(doc);
                        //using (reader)
                        //{
                        //    xmlResponse = sr.Deserialize(reader) as Envelope;
                        //}
                        //System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                        //xmlResponse = (Envelope)soapFormatter.Deserialize(secondstream);
                    }
                    //XmlDocument xmlSoapRequest = new XmlDocument();
                    //using (Stream savestream = str.BaseStream)
                    //{
                    //    using (StreamReader readStream = new StreamReader(savestream, Encoding.UTF8))
                    //    {
                    //        xmlSoapRequest.Load(readStream);
                    //        xmlPayload = xmlSoapRequest.SelectSingleNode("//Envelope/Body/GetRequisitionByDateResponse/").InnerText;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    //DumpException(ex);
                    //this.ComponentMetaData.FireInformation(54, "", "Failed to deserialize: " + ex.Message + " Inner: " + ex.InnerException + " Source: " + ex.Source, "", 43, ref b);
                }
                return xmlResponse;
            }
            public static T DeserializeFromXml<T>(string xml)
            {
                T result;
                var ser = new XmlSerializer(typeof(T));
                using (var tr = new StringReader(xml))
                {
                    result = (T)ser.Deserialize(tr);
                }
                return result;
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
            public Body Body { get; set; }
            [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Soap { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
        }
    }
        
