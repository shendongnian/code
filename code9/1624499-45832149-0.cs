     public object UploadFile(string srcfile, string destFilePath, bool force = true)
        {
            var uploadurl = string.Format(UploadUrl, _datalakeAccountName, destFilePath);
            var stream = File.OpenRead(srcfile);
            HttpContent fileStreamContent = new StreamContent(stream);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Bearer",  _accesstoken.access_token);
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                var response = client.PutAsync(uploadurl, fileStreamContent).Result;
                return new { Status = response.StatusCode, Message = response.ReasonPhrase, details = response.ToString() };
            }
        }
