    public HttpResponseMessage Get () {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(FooCollection));
      System.IO.StringWriter stringWriter = new System.IO.StringWriter();
      XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
      FooCollection foos = new FooCollection();
      // code to populate FooCollection model, assign namespaces, etc
      xmlSerializer.Serialize(stringWriter, foos, namespaces);
      // Now we can manipulate stringWriter value however is needed to replace the element names
      return new HttpResponseMessage() {
        Content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/xml")
      };
    }
