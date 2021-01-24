    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                LogRecord record = doc.Descendants("LogRecord").Select(x => new LogRecord()
                {
                    Message = (string)x.Element("Message"),
                    SendTime = (DateTime)x.Element("SendTime"),
                    Sender = (string)x.Element("Sender"),
                    Recipient = (string)x.Element("Recipient")
                }).OrderByDescending(x => x.SendTime).FirstOrDefault();
     
            }
        }
        public class LogRecord
        {
            public string Message { get; set; }
            public DateTime SendTime { get; set; }
            public string Sender { get; set; }
            public string Recipient { get; set; }
        }
     
    }
