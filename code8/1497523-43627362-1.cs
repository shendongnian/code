     WebRequest req = WebRequest.Create(url);
            req.Method = "POST";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("key:Secret"));
            req.Credentials = new NetworkCredential("username", "password");
            var postData = "grant_type=client_credentials";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = req.GetResponse();
            // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
            String status = (string)o.SelectToken(".access_token");
   
