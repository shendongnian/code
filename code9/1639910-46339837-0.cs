        public void SaveFile(HttpListenerContext context)
        {
            // Get the data from the HTTP stream
            var body = new StreamReader(context.Request.InputStream).ReadToEnd();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(body);
            xmlDocument.Save("Settings.xml");
        }
    
    
    
    
