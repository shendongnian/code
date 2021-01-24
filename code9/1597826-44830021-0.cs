     public static void Downloadfiles(string username, string password, string account, string repository, string pathToSave)
        {
            var creds = Base64Encode(String.Format("{0}:{1}", username, password));
            var url = String.Format("https://bitbucket.org/{0}/{1}/get/tip.zip", account, repository);
            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", "Basic " + creds);
                client.Headers.Add("Content-Type", "application/octet-stream");
                client.DownloadFile(url, pathToSave);
            }
        }
