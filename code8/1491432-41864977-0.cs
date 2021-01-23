    private string setData(string address, string serializedData, WebMethods type)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            byte[] data = Encoding.ASCII.GetBytes(serializedData);
            WebRequest request = WebRequest.Create(address);
            CredentialCache mycreds = new CredentialCache();
            mycreds.Add(new Uri(_baseAddress), "Basic", new NetworkCredential(_username, _password));
            request.Credentials = mycreds;
            request.Method = type.ToString();
            request.ContentLength = data.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            string responseFromRequest = ((HttpWebResponse)response).StatusDescription;
            response.Close();
            return responseFromRequest;
        }
