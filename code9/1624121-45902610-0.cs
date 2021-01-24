                    var uri = new Uri(string.Format(_host + "webserver/SesTokInfo", string.Empty));
                    var webRequest = WebRequest.Create(uri);
                    using (var response = webRequest.GetResponse() as HttpWebResponse)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var content = reader.ReadToEnd();
                            XmlDocument xDocument = new XmlDocument();
                            xDocument.LoadXml(content);
                            XmlElement root = xDocument.DocumentElement;
                            if (IsResponseReturned(root))
                            {
                                GlobalConfig.SessionId = root.GetElementsByTagName("SesInfo")[0].InnerText;
                                GlobalConfig.Token = root.GetElementsByTagName("TokInfo")[0].InnerText;
    
                            }
                        }
                    }
