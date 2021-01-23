                 HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                string authInfo = "username" + ":" + "Password";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers[HttpRequestHeader.Authorization] = "Basic " + authInfo;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
               using (var responseStream = response.GetResponseStream())
                {
                   StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            return reader.ReadToEnd();
                }
            
                
               
