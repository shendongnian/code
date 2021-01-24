        public static async Task<Google.Apis.Drive.v3.Data.File> UploadSync(DriveService driveService, string filepath)
        {
            string destfilename = Path.GetFileName(filepath);
            List<string> parents = new List<string>();
            parents.Add("root");
            // Prepare the JSON metadata
            string json = "{\"name\":\"" + destfilename + "\"";
            if (parents.Count > 0)
            {
                json += ", \"parents\": [";
                foreach (string parent in parents)
                {
                    json += "\"" + parent + "\", ";
                }
                json = json.Remove(json.Length - 2) + "]";
            }
            json += "}";
            Debug.WriteLine(json);
            Google.Apis.Drive.v3.Data.File uploadedFile = null;
            try
            {
                System.IO.FileInfo info = new System.IO.FileInfo(filepath);
                ulong fileSize = (ulong)info.Length;
                var uploadStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                var insert = driveService.Files.Create(new Google.Apis.Drive.v3.Data.File { Name = destfilename, Parents = new List<string> { "root" } }, uploadStream, "application/octet-stream");
                Uri uploadUri = insert.InitiateSessionAsync().Result;
                int chunk_size = ResumableUpload.MinimumChunkSize;
                int bytesSent = 0;
                while (uploadStream.Length != uploadStream.Position)
                {
                    byte[] temp = new byte[chunk_size];
                    int cnt = uploadStream.Read(temp, 0, temp.Length);
                    if (cnt == 0)
                        break;
                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uploadUri);
                    httpRequest.Method = "PUT";
                    httpRequest.Headers["Authorization"] = "Bearer " + ((UserCredential)driveService.HttpClientInitializer).Token.AccessToken;
                    httpRequest.ContentLength = (long)cnt;
                    httpRequest.Headers["Content-Range"] = string.Format("bytes {0}-{1}/{2}", bytesSent, bytesSent + cnt - 1, fileSize);
                    using (System.IO.Stream requestStream = httpRequest.GetRequestStreamAsync().Result)
                    {
                        requestStream.Write(temp, 0, cnt);
                    }
                    HttpWebResponse httpResponse;
                    try
                    {
                        httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        httpResponse = (HttpWebResponse)ex.Response;
                    }
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    { }
                    else if ((int)httpResponse.StatusCode != 308)
                        break;
                    bytesSent += cnt;
                    Console.WriteLine("Uploaded " + bytesSent.ToString());
                }
                if (bytesSent != uploadStream.Length)
                {
                    return null;
                }
                // Try to retrieve the file from Google
                FilesResource.ListRequest request = driveService.Files.List();
                if (parents.Count > 0)
                    request.Q += "'" + parents[0] + "' in parents and ";
                request.Q += "name = '" + destfilename + "'";
                FileList result = request.Execute();
                if (result.Files.Count > 0)
                    uploadedFile = result.Files[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return uploadedFile;
        }
