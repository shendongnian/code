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
            const string origXml = @"c:\temp\test1.xml";
            const string backupXml = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument origDoc = XDocument.Load(origXml);
                XDocument backupDoc = XDocument.Load(backupXml);
                var groups = (from orig in origDoc.Descendants("task")
                              join backup in backupDoc.Descendants("task") on (int)orig.Attribute("id") equals (int)backup.Attribute("id")
                              select new { orig = orig, backup = backup }).ToList();
                foreach (var group in groups)
                {
                    group.orig.Descendants().Where(x => x.Name.LocalName == "CipherValue").FirstOrDefault().Value = 
                        (string)group.backup.Descendants().Where(x => x.Name.LocalName == "CipherValue").FirstOrDefault();  
                }
            }
        }
    }
