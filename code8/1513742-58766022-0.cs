      private string GetWebService(string token, int testId, string phone)
        {
            try
            {
                var serviceUrl = "https://test.com/Soap";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                httpWebRequest.ContentType = "text/xml";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var xmlData = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:doc=\"http://test.com\">" +
                    "   <soapenv:Header/>" +
                    "   <soapenv:Body>" +
                    "      <doc:AskForStackOverFlow>" +
                    "         <doc:token>" + token + "</doc:token>" +
                    "         <doc:testId>" + testId+ "</doc:testId>" +
                    "         <doc:phone>" + phone + "</doc:phone>" +
                    "         <doc:startTime>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</doc:startTime>" +
                    "      </doc:AskForStackOverFlow>" +
                    "   </soapenv:Body>" +
                    "</soapenv:Envelope>";
                    
                    streamWriter.Write(xmlData);
                }
                var xmlResult = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    xmlResult = streamReader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(xmlResult))
                    return "";
                var result = "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlResult);
                XmlNodeList nodes = doc.GetElementsByTagName("ns1:AskForStackOverFlowResult");
                foreach (XmlNode item in nodes)
                {
                    result = item.InnerText;
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
