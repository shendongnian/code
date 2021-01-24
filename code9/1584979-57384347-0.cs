    public static void assignWatcher(string issueKey, string watcher, JiraServerInfo JInfo)
        {
            var client = new RestClient(JInfo.JServerName + "rest/api/2/issue/" + issueKey + "/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Basic " + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(JInfo.JUsername + ":" + JInfo.JPassword)));
            request.AddParameter("application/json", "\"" + watcher + "\"\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
