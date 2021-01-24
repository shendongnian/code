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
     
        private string GetValueFromDocumentByXPath(XPathDocument doc, string xpath)
        {
            var nav = doc.CreateNavigator();
            var it = nav.Select(xpath, nameSpaceManager_);
            if (it.MoveNext())
            {
                return it.Current.Value;
            }
            return "";
        }
        private void SetValueToDocumentByXPath(XPathDocument doc, string xpath, string value)
        {
            var nav = doc.CreateNavigator();
            var it = nav.Select(xpath, nameSpaceManager_);
            if (it.MoveNext())
            {
                it.Current.SetValue(value);
            }
        }
