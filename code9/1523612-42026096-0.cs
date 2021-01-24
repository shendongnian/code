        private static XmlDocument LoadXMLFromUri(string uri)
        {
            var req = WebRequest.CreateHttp(uri);
            var resTask = req.GetResponseAsync();
            resTask.Wait();
            XmlDocument doc = new XmlDocument();
            doc.Load(resTask.Result.GetResponseStream());
            return doc;
        }
        private string ConvertXmlDocumentToString(XmlDocument doc)
        {
            StringWriter sw = new StringWriter();
            XmlWriter tx = XmlWriter.Create(sw);
            doc.WriteTo(tx);
            return sw.ToString();
        }
