    public T Execute<T>()
        {
            var request = createWebRequest();
            request.Method = this.Method;
            applyPostData(ref request);
            request.ContentType = "application/json";
            request.UserAgent = "generic-http-dotnet-client/3.5/v1 (gzip)";
            using(var response = (HttpWebResponse)request.GetResponse())
            using(var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd())
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                catch (Exception ex)
                {
                    //log something with ex
                    return default(T);
                }
            }
        }
