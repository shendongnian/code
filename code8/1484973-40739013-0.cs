    public TResponse Send<TRequest, TResponse>(string url, TRequest request)
    {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
    
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.ContentType = "application/json";
    		
    		ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
    
    		var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            using (var requestStream = webRequest.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
            }
    
            try
            {
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (var responseStream = webResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            var responseData = reader.ReadToEnd();
                            webResponse.Close();
    
                            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseData);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw ProcessWebException(ex); // ToDo
            }
    }
