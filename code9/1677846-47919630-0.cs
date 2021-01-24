        public void takeit()
        {
            string jsonResult = "Cannot Connect! Try Later.";
            try
            {
                IWebProxy defWebProxy = WebRequest.DefaultWebProxy;
                def.Credentials = CredentialCache.DefaultCredentials;
                WebClient clien = new WebClient { Proxy = def};
                jsonResult = clien.DownloadString("http://www.google.com");
                using (WebClient client = new WebClient())
                {
                    string url = "http://www.google.com";
                    jsonResult = client.DownloadString(url); 
                }
            }
            catch (Exception ex)
            {
                jsonResult = ex.StackTrace;
            }
            MessageBox.Show(jsonResult);
        }
