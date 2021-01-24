    // setup the DTO
    var s = new Envelope {
      Body = new Body {
         Login = new Login {
           UserName = "test" ,
           Password = "test" ,
           WebSite = "ecourier"
         }
      }
    };
    // setup namespaces and their prefixes    
    var ns = new XmlSerializerNamespaces();
    ns.Add("SOAP", "http://schemas.xmlsoap.org/soap/envelope/");
    ns.Add("m","http://www.e-courier.com/software/schema/public/");
    // create the serializer
    var ser = new XmlSerializer(typeof(Envelope));
    using(var ms = new MemoryStream())
    {
        // write the DTO to the MemoryStream
        ser.Serialize(ms, s, ns);
    
        using(var wc = new WebClient()) {
           wc.Encoding = System.Text.Encoding.UTF8;
           var resp = wc.UploadData(
              "http://www.e-courier.com/ecourier/software/xml/XML.asp",
              ms.ToArray()
         );
         Console.WriteLine(Encoding.UTF8.GetString(resp));
        }
    }
