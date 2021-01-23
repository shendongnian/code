    Image mySelect = new Image();
            mySelect.Caption = "Caption";
            mySelect.Title = "Title";
            mySelect.UrlLocation = "www";
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("image", "http://flibble");
            XmlSerializer ser = new XmlSerializer(typeof(Image));
            ser.Serialize(Console.Out, mySelect,ns);
