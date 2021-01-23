    string result = "";
    using (WebClient webClient = new WebClient())
    {
        string apiUrl = string.Format(@"https://webapi.yourdomain.com/api/{0}/{1}/", model.UserName, model.UserPass);
        webClient.Headers["Accept"] = "application/json";
        webClient.Encoding = System.Text.Encoding.UTF8;
        result = webClient.DownloadString(new Uri(apiUrl));
    }
    ResponseMyObj resultObj = JsonConvert.DeserializeObject<ResponseMyObj >(result);
