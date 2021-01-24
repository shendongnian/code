        private static XPathDocument LoadXMLFromUri(string uri)
        {
            var req = WebRequest.CreateHttp(uri);
            var resTask = req.GetResponseAsync();
            resTask.Wait();
            XPathDocument doc = new XPathDocument(resTask.Result.GetResponseStream());
            return doc;
        }
        private string ConvertXmlDocumentToString(XmlDocument doc)
        {
            StringWriter sw = new StringWriter();
            XmlWriter tx = XmlWriter.Create(sw);
            doc.WriteTo(tx);
            return sw.ToString();
        }
