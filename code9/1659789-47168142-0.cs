    public string GetRequest(string Email)
        {
            try
            {
                string Response = string.Empty;
                string url = _EndPoint + "?_queryFilter=userName+eq+" + '"' + Email + '"';
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_UserName + ":" + _Password));
                HttpWebRequest Request = WebRequest.Create(url) as HttpWebRequest;
                Request.Headers.Add("Authorization", "Basic " + svcCredentials);
                Request.Method = _HTTPMethod.ToString();
                using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Error: " + response.StatusCode.ToString());
                    }
                    using (Stream responsestream = response.GetResponseStream())
                    {
                        if (responsestream != null)
                        {
                            using (StreamReader reader = new StreamReader(responsestream))
                            {
                                Response = reader.ReadToEnd();
                            }
                        }
                    }
                }
                return Response;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
