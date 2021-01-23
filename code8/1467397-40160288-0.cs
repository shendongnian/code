    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    using System.Xml.Serialization;
    namespace ConsoleApplication21
    {
        class Program
        {
            const string FILEName = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ISTimetables));
                XmlTextReader reader = new XmlTextReader(FILEName);
                ISTimetables tables = (ISTimetables)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("Notifications")]
        public partial class ISTimetables
        {
            [XmlElement("Notification")]
            public List<ISNotification> Notifications { get; set; }
        }
        [XmlRoot("Notification")]
        public partial class ISNotification
        {
            public ISNotification()
            {
                On = new List<ISProcessStep>();
                Notify = new List<ISNotify>();
            }
            [XmlElement]
            public List<ISProcessStep> On { get; set; }
            [XmlElement]
            public List<ISNotify> Notify { get; set; }
        }
        [Serializable()]
        public partial class ISNotify
        {
            public string Email { get; set; }
            public string SimpleEmail { get; set; }
            public string SMS { get; set; }
        }
        [Serializable()]
        public enum ISProcessStep
        {
            [XmlEnum("Calculated")]
            Calculated,
            [XmlEnum("Reported")]
            Reported,
            [XmlEnum("Customer Approved")]
            CustomerApproved,
            [XmlEnum("Rejected")]
            Rejected
        }
    }
