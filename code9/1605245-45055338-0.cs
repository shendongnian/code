        public async static Task<string> CallWebService(string webWebServiceUrl, 
                                    string webServiceNamespace, 
                                    string methodVerb,
                                    string methodName, 
                                    Dictionary<string, string> parameters) {
            const string soapTemplate = 
            @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                            xmlns:{0}=""{2}"">
                <soapenv:Header />
                <soapenv:Body>
                    <{0}:{1}>
                        {3}
                    </{0}:{1}>
                </soapenv:Body>
            </soapenv:Envelope>";
            var req = (HttpWebRequest)WebRequest.Create(webWebServiceUrl);
            req.ContentType =   "text/xml"; //"application/soap+xml;";
            req.Method = "POST";
            
            string parametersText;
            if (parameters != null && parameters.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var oneParameter in parameters)
                    sb.AppendFormat("  <{0}>{1}</{0}>\r\n", oneParameter.Key, oneParameter.Value);
                parametersText = sb.ToString();
            }
            else
            {
                parametersText = "";
            }
            string soapText = string.Format(soapTemplate, 
                            methodVerb, methodName, webServiceNamespace, parametersText);
            Console.WriteLine("SOAP call to: {0}", webWebServiceUrl);
            Console.WriteLine(soapText);
            using (Stream stm = await req.GetRequestStreamAsync())
            {
                using (var stmw = new StreamWriter(stm))
                {
                        stmw.Write(soapText);
                }
            }
            var responseHttpStatusCode = HttpStatusCode.Unused;
            string responseText = null;
            using (var response = (HttpWebResponse)req.GetResponseAsync().Result) {
                responseHttpStatusCode = response.StatusCode;
                if (responseHttpStatusCode == HttpStatusCode.OK)
                {
                    int contentLength = (int)response.ContentLength;
                    if (contentLength > 0)
                    {
                        int readBytes = 0;
                        int bytesToRead = contentLength;
                        byte[] resultBytes = new byte[contentLength];
                        using (var responseStream = response.GetResponseStream())
                        {
                            while (bytesToRead > 0)
                            {
                                // Read may return anything from 0 to 10. 
                                int actualBytesRead = responseStream.Read(resultBytes, readBytes, bytesToRead);
                                // The end of the file is reached. 
                                if (actualBytesRead == 0)
                                    break;
                                readBytes += actualBytesRead;
                                bytesToRead -= actualBytesRead;
                            }
                            responseText = Encoding.UTF8.GetString(resultBytes);
                            //responseText = Encoding.ASCII.GetString(resultBytes);
                        }
                    }
                }
            }
            return responseText;
            //return responseHttpStatusCode;
        }
