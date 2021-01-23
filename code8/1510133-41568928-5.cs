    public string Requst(string Url, string Method, object Parameter)
    {
            try
            {
                var result = "";
                var url = Url;
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                webrequest.ContentType = "application/json";
                webrequest.Method = Method.ToString();
                NetworkCredential netcred = new NetworkCredential(){
                    Domain = "",
                    UserName = "",
                    Password = ""
                };
                webrequest.Credentials = netcred;
                if (Method.ToString() == "POST")
                {
                    using (var streamWriter = new StreamWriter(webrequest.GetRequestStream()))
                    {
                        streamWriter.Write(new JavaScriptSerializer().Serialize(Parameter));
                    }
                }
                var httpResponse = (HttpWebResponse)webrequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                return "-1";
            }
     }
