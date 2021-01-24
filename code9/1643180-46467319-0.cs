            Public FileStreamResult GenerateXML() {
             using(MemoryStream ms = new MemoryStream()) {
              XmlWriterSettings xws = new XmlWriterSettings();
              xws.OmitXmlDeclaration = true;
              xws.Indent = true;
              using(XmlWriter xw = XmlWriter.Create(ms, xws)) {
               Checker checker = new Checker();
               //Your Model - Consider renaming :)
               XMLWriter xmlWriter = new XMLWriter();
               string userid = xmlWriter.UserId.ToString();
               string date = xmlWriter.Date;
               int hours = xmlWriter.Hours;
               string role = xmlWriter.Role;
               userid = checker.User.UserName;
               date = checker.Date.ToString();
               hours = int.Parse(checker.Total.ToString());
               role = checker.User.Roles.ToString();
               XDocument doc = new XDocument(
                new XElement("Tidrans",
                 new XElement("tidkod", role),
                 new XElement("datum", date),
                 new XElement("timmar", hours)
                )
               );
               doc.WriteTo(xw);
              }
             }
             return File(ms, "text/xml", "Sample.xml")
            }
