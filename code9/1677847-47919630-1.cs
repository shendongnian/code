        public void takeit()
        {
            string jsonResult = "Cannot Connect! Try Later.";
            try
            {
                IWebProxy defWebProxy = WebRequest.DefaultWebProxy;
                defWebProxy.Credentials = CredentialCache.DefaultCredentials;
                WebClient clien = new WebClient { Proxy = defWebProxy };
                jsonResult = clien.DownloadString("http://www.google.com");
            }
            catch (Exception ex)
            {
                jsonResult = ex.StackTrace;
            }
            MessageBox.Show(jsonResult);
        }
