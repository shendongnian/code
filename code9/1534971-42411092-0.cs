        public bool CreateFolder(string _strDirectory)
        {
            bool result = true;
            System.Net.HttpWebRequest Request;
            CredentialCache MyCredentialCache;
            MyCredentialCache = new System.Net.CredentialCache();
            MyCredentialCache.Add(new System.Uri(_strDirectory), "NTLM", new System.Net.NetworkCredential(UserName, Password));
            Request = (System.Net.HttpWebRequest)HttpWebRequest.Create(_strDirectory);
            Request.Credentials = MyCredentialCache;
            Request.Method = "MKCOL";
            Request.KeepAlive = false;
            Request.Timeout = 500;
            Request.Proxy = null;
            Request.ServicePoint.ConnectionLeaseTimeout = 500;
            Request.ServicePoint.MaxIdleTime = 500;
            try
            {
                using (var response = (System.Net.HttpWebResponse)Request.GetResponse())
                {
                }
            }
            catch (Exception)
            {
            }
            Request.Abort();
            GC.Collect();
            return result;
        }
