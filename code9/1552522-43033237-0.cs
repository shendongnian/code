    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
    {
    var httpWebResponse = response.GetResponseStream();
                using (var sr = new StreamReader(httpWebResponse))
                {
                    responseText = sr.ReadToEnd();
                }
    }
