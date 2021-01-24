        [HttpPost]
        public List<Thing> GetThings(ValidatedRequest requestParams)
        {
            List<Thing> ListThings = new List<Thing>();
            if (requestParams == null)
                throw new UnauthorizedAccessException("Unauthorized");
            if (string.IsNullOrEmpty(requestParams.ValidationToken))
                throw new UnauthorizedAccessException("Unauthorized");
            JObject obj = null;
            try
            {
                var wc = new WebClient();
                var googleVerificationURL = string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}&remoteip={2}", ConfigurationManager.AppSettings["gReCaptchaPrivateKey"], requestParams.ValidationToken, remoteIpAddress);
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ProxyAddress"].Trim()))
                {
                    wc.Proxy = new WebProxy(ConfigurationManager.AppSettings["ProxyAddress"].Trim());
                    wc.Proxy.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ProxyUsername"].Trim(), ConfigurationManager.AppSettings["ProxyPassword"]);
                }
                var result = wc.DownloadString(googleVerificationURL);
                wc.Dispose();
                obj = JObject.Parse(result);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to connect to reCaptcha", ex);
            }
            if(obj == null || !(bool)obj.SelectToken("success"))
                throw new UnauthorizedAccessException("Unauthorized");
            ... Rest of the code ... 
         }
