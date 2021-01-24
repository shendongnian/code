     var request = (HttpWebRequest)WebRequest.Create(BaseAddress + "/auth");
            var postData = "username=" + _username ;
            postData += "&password=" + _password;
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var stream = request.GetRequestStreamAsync().Result)
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponseAsync().Result;
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var tokObj = JsonConvert.DeserializeObject<AuthResult>(responseString);
            string token = tokObj.Token;
            return token;
