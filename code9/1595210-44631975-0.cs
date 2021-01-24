            string soap = null;
            try
            {
                StreamReader str = new StreamReader(@"F:\xxx\some.xml");
                soap = str.ReadToEnd();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://192.168.xxx.xx:xxxx/bla-bla-bla/AccountsPayableManagerPort?WSDL");
                req.ContentType = "text/xml;charset=\"UTF-8\"";
                req.Accept = "text/xml";
                req.Method = "POST";
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(soap);
                    }
                }
                using (WebResponse response = req.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
