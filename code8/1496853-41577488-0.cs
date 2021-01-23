    public static bool AddWorkItem()
        {
            HttpWebResponse response = null;
            string workItem = "12345678";
            string pullReqId = string.Empty;
            string artifactId = string.Empty;
            string moduleName = "abcd";
            
            pullReqId = "123456";
            artifactId = "vstfs:///Git/PullRequestId/xxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tfs-glo-xxxxxxxxx.visualstudio.com/_apis/wit/workItems/" + workItem);
                request.Accept = "application/json;api-version=3.0;excludeUrls=true";
                request.ContentType = "application/json-patch+json";
                request.Referer = "https://tfs-glo-xxxxxxxxx.visualstudio.com/Apps/_git/" + moduleName + "/pullrequest/" + pullReqId + "?_a=overview";
                string _auth = string.Format("{0}:{1}", "GITUserName", "GITPassword");
                string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
                string _cred = string.Format("{0} {1}", "Basic", _enc);
                request.Headers[HttpRequestHeader.Authorization] = _cred;
                request.Method = "PATCH";
                string body = @"[{""op"":0,""path"":""/relations/-"",""value"":{""attributes"":{""name"":""Pull Request""},""rel"":""ArtifactLink"",""url"":" + "\"" + artifactId + "\"" + "}}]";
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                Log.Write("Add Work Item: ", ex);
                return false;
            }
            return true;
        }
