    var doc = new XmlDocument();
    doc.Load("D:/Chrome/Quartz.NET-2.4.1/src/Quartz.Examples/quartz_jobs.xml");
    var namespaceManager = new XmlNamespaceManager(doc.NameTable);
    namespaceManager.AddNamespace("x", "http://quartznet.sourceforge.net/JobSchedulingData");
    XmlNode selectedNode = doc.SelectSingleNode("x:job-scheduling-data/x:schedule/x:trigger/x:cron/x:cron-expression", namespaceManager);
    if (selectedNode != null)
    {
        selectedNode.InnerXml = "0";
        doc.Save("D:/Chrome/Quartz.NET-2.4.1/src/Quartz.Examples/quartz_jobs.xml");
    }
