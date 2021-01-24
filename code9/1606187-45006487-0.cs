    var doc = XDocument.Load(File.Open("D:/Chrome/Quartz.NET-2.4.1/src/Quartz.Examples/quartz_jobs.xml",FileMode.Open));
    
    var childElements = doc.DescendantNodes().Where(n => n.NodeType == XmlNodeType.Element).Select(n => (n as XElement));
    var cronElement = childElements.Where(e => e.Name.LocalName == "cron-expression").FirstOrDefault();
    cronElement.SetValue("0");
    doc.Save("D:/Chrome/Quartz.NET-2.4.1/src/Quartz.Examples/quartz_jobs.xml");
