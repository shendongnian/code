    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = 
                    "<cookie page=\"1\">" + 
                    "<pz_requestid last=\"{987A23F4-8582-E711-8114-005056B74623}\" first=\"{9F2E4A8C-EB7D-E711-8116-005056B71CCD}\" />" +
                    "</cookie>";
                XDocument doc = XDocument.Parse(xml);
                Entityidfieldid entityidfieldid = doc.Descendants("cookie").Elements().Select(x => new Entityidfieldid() {
                    name = x.Name.LocalName,
                    last = (string)x.Attribute("last"),
                    first = (string)x.Attribute("first")
                }).FirstOrDefault();
            }
        }
        public partial class Entityidfieldid
        {
            public string name { get; set; }
            public string last { get; set; }
            public string first { get; set; }
        }
    }
