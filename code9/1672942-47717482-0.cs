    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
      
            static void Main(string[] args)
            {
                string xml =
                   "<DTSControl>" +
                        "<Version>1.0</Version>" +
                        "<AddressType>DTS</AddressType>" +
                        "<MessageType>Data</MessageType>" +
                        "<From_DTS>x26OT075</From_DTS>" +
                        "<To_DTS>x26OT075</To_DTS>" +
                        "<Subject>ECDS Submission</Subject>" +
                        "<LocalId>TEST-delta.jsonl</LocalId>" +
                        "<WorkflowId>SUS_CDS</WorkflowId>" +
                        "<Encrypted>N</Encrypted>" +
                        "<Compress>Y</Compress>" +
                   "</DTSControl>";
                XDocument doc = XDocument.Parse(xml);
                string localId = (string)doc.Descendants("LocalId").FirstOrDefault();
            }
        }
    }
