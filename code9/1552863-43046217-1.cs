        public static void PerformSOAPRequest(string xml_message)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:62147/Service1.svc/Soap/");
            webRequest.Headers.Add(@"SOAPAction", "http://tempuri.org/IService1/GetData");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(xml_message);
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
        }
