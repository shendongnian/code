            string Testing = "https://wwwcie.ups.com/rest/Rate";
            string Production = "https://onlinetools.ups.com/rest/Rate";
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(upsRate);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11; //This line will ensure the latest security protocol for consuming the web service call.
            WebRequest httpWebRequest = WebRequest.Create(Production);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string returnResult = "";
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                returnResult = streamReader.ReadToEnd();
            }
            if (string.IsNullOrEmpty(returnResult))
            {
                return NotFound();
            }
            return Ok(returnResult);
