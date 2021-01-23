    private static String Post(String url,
                int timeout)
        {
            
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "POST";
            if (timeout != 0)
                req.Timeout = timeout;
            req.Headers.Set("client_id", "client_id");
            req.Headers.Set("client_secret", "client_secret");
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("mailbox_id", "mailbox_id");
            byte[] rawData = Encoding.UTF8.GetBytes(Encode(data));
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = rawData.Length;
            String ret = null;
            using (Stream s = req.GetRequestStream())
            {
                s.Write(rawData, 0, rawData.Length);
                using (HttpWebResponse res = req.GetResponse() as HttpWebResponse)
                {
                    using (Stream s2 = res.GetResponseStream())
                    {
                        using (StreamReader r = new StreamReader(s2, Encoding.UTF8))
                        {
                            ret = r.ReadToEnd();
                        }
                    }
                }
            }
            return ret;
        }
        public static String Encode(Dictionary<String, String> data)
        {
            StringBuilder s = new StringBuilder();
            foreach (KeyValuePair<String, String> o in data)
            {
                s.AppendFormat("{0}={1}&", o.Key, HttpUtility.UrlEncode(o.Value));
            }
            char[] trim = { '&' };
            String ret = s.ToString().TrimEnd(trim);
            return ret;
        }
