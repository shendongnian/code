            var request = WebRequest.CreateHttp(myUrl + "/" + uri);
            request.Credentials = new NetworkCredential(myUserName, myPassword, myDomain);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string jsonstring = JsonConvert.SerializeObject(myJsonobject, Formatting.Indented);
                streamWriter.Write(jsonstring);
                streamWriter.Flush();
            }
