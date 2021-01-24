                        string str = Inventory();
                        using (WebClient httpclient = new WebClient())
                        {
                            //string str = "abc";
                            string url = "http://localhost:51411/api/MobileAPI/Inventory?TenantId=" + CommonClass.tenantId;
                            ASCIIEncoding encoding = new ASCIIEncoding();
                            byte[] data = encoding.GetBytes(str);
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                            request.Method = "Post";
                            request.ContentLength = data.Length;
                            request.ContentType = "application/json";
                            using (Stream stream = request.GetRequestStream())
                            {
                                stream.Write(data, 0, data.Length);
                            }
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        }
