        private static void DoSerialize(MyData m, XmlSerializer xs)
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            var sww = new System.IO.StringWriter();
            XmlWriter writer = XmlWriter.Create(sww, settings);
            xs.Serialize(writer, m);
            Console.WriteLine(sww.ToString().Replace("><", ">\r\n<"));
        }
