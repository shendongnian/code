        public string PutOurStylesInBlockForWordExport(string pageSource, string webRoot)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<style type=""text/css"">");
            HttpWebRequest req = WebRequest.Create(webRoot + "Styles/reset.css") as HttpWebRequest;
            HttpWebRequest req2 = WebRequest.Create(webRoot + "Styles/style.css") as HttpWebRequest;
            CookieContainer cc = new CookieContainer();
            req.CookieContainer = cc;
            req2.CookieContainer = cc;
            var cookies = HttpContext.Current.Request.Cookies;
            foreach (string key in cookies.AllKeys)
            {
                Cookie c = new Cookie(cookies[key].Name, cookies[key].Value);
                Uri root = new Uri(webRoot);
                req.CookieContainer.Add(root, c);
                req2.CookieContainer.Add(root, c);
            }
            System.Net.WebResponse resp = req.GetResponse();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
            {
                sb.Append(sr.ReadToEnd().Trim());
            }
            
            System.Net.WebResponse resp2 = req2.GetResponse();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(resp2.GetResponseStream()))
            {
                sb.Append(sr.ReadToEnd().Trim());
            }
            sb.AppendLine(@"</style>");
            return sb.ToString();
        }
