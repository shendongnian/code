    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication34
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<commit><subject><![CDATA[Fixed:Bu| Integer Fields Not Saving with >10 digits [ 3f19d010-c472-4ae6-9d29-b727707fe867 ]]]></subject></commit>" +
                    "<commit><subject><![CDATA[Merge branch 'iq17' of github.iqsmartapp.com:DEV/EnterpriseDesktop into iq17]]></subject></commit><commit><subject><![CDATA[Fixed:Bug-5 | Regression - [Desktop - Action Menu] - Item Print option do not download the PDF file instead displaying the blank screen in the next window. [ def7b8cb-6819-4380-9a57-5af635f9b70b ]]]></subject></commit>";
                xml = "<Root>" + xml + "</Root>";
                StringReader sReader = new StringReader(xml);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.CheckCharacters = false;
                XmlReader reader = XmlReader.Create(sReader);
                XDocument  elements = XDocument.Load(reader); 
                List<string> subjects = elements.Descendants("subject").Select(x => (string)x).ToList();
                List<string> guids = subjects.Select(x => Regex.Match(x, @"(?'guid'([a-z0-9]+-){4}[a-z0-9]+)").Groups["guid"].Value.Trim()).Where(x => x.Length > 0).ToList(); 
     
             } 
     
        }
      
     
    }
