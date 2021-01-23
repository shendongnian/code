    using (var svc = new ListsService.Lists())
    {
           svc.Credentials = new NetworkCredential(userName, password, domain);
           var list = svc.GetList("Pages");
           var listXml = XElement.Parse(list.OuterXml);
           var lastModified = listXml.Attribute("Modified").Value;
      
    }
