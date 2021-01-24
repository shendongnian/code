    var username = "test";
    var password = "test";
    
    var xdoc = new XDocument();
    
    var soapNs = (XNamespace) "http://schemas.xmlsoap.org/soap/envelope/";
    var m = (XNamespace) "http://www.e-courier.com/software/schema/public/";
    
    // Request body
    // notice the namespace m used here!
    var login = new XElement(m + "Login", 
      new XAttribute("UserName", username),
      new XAttribute("Password", password)
    );
    
    // mandatory SOAP stuff
    // notice the namespace soapNs here
    xdoc.Add(new XElement(soapNs + "Envelope",
      new XElement(soapNs +"Body", 
        login
      )
    ));
    
    using(var wc = new WebClient()) {
      wc.Encoding = System.Text.Encoding.UTF8;
      wc.Headers.Add("Content-Type","text/xml");
      var resp =  wc.UploadString(
         "http://www.e-courier.com/ecourier/software/xml/xml.asp",  // this echo's
         xdoc.ToString()); // this is the XML payload
      Console.WriteLine(resp);
    }
