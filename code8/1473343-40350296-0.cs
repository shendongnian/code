    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                CustomerInfo info = new CustomerInfo()
                {
                    Sender = new CustomerSender()
                    {
                        Address = "123",
                        City = "North Pole"
                    },
                    Reciever = new CustomerReceiver()
                    {
                        Address = "456",
                        City = "South Pole"
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(CustomerInfo));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, info);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlRoot("Sender")]
        public class CustomerSender
        {
            [XmlElement("SenderAddress")]
            public string Address { get; set; }
            [XmlElement("SenderCity")]
            public string City { get; set; }
        }
        [XmlRoot("Receiver")]
        public class CustomerReceiver
        {
            [XmlElement("ReceiverAddress")]
            public string Address { get; set; }
            [XmlElement("ReceiverCity")]
            public string City { get; set; }
        }
        public class CustomerInfo
        {
            [XmlElement("Sender")]
            public CustomerSender Sender { get; set; }
            [XmlElement("Receiver")]
            public CustomerReceiver Reciever { get; set; }
        }
    }
