    public static string UploadFile(string targetUrl,ICredentials credentials, string sourcePath)
    {
            var request = WebRequest.Create(targetUrl);
            request.Method = "PUT";
            request.Credentials = credentials;
            using (var fileStream = File.OpenRead(sourcePath))
            using (var requestStream = request.GetRequestStream())
            {
                fileStream.CopyTo(requestStream);
            }
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
    }
