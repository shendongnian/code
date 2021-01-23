    public void DownloadFile(string serverFilePath, string destPath)
    {
            var url = string.Format("{0}/{1}", ServerURL, serverFilePath);
            CreateDirectoryIfNotExists(Path.GetDirectoryName(destPath));
            var request = System.Net.HttpWebRequest.Create(url);
            request.Credentials = _clientCtx.Credentials;
            using (var sr = new StreamReader(request.GetResponse().GetResponseStream())) {
                using (var sw = new StreamWriter(destPath)) {
                    sw.Write(sr.ReadToEnd());
                }
            }
        }
