    [Route("api/markers/getgrantsis")]
    public HttpResponseMessage GetGrantsIS()
    {
      XmlDocument docContent = GetXmlDataFromDB();
      return new HttpResponseMessage
      {
        Content = new StringContent(docContent.InnerXml.ToString(), Encoding.UTF8, "application/xml")
       };
    
    }
