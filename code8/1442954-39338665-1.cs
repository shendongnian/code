    public void DownloadFile(string serverFilePath, string destPath)
            {
                var url = string.Format("{0}/{1}", ServerURL, serverFilePath);
                createDirectiory(Path.GetDirectoryName(destPath)); // this method creates your directory
                var request = System.Net.HttpWebRequest.Create(url);
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                using (var sReader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    using (var sWriter = new StreamWriter(destPath))
                    {
                        sWriter.Write(sReader.ReadToEnd());
                    }
                }
            }
