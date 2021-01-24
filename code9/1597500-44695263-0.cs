    HttpClient client = new HttpClient();
    var json = client.GetStringAsync(string.Format(Url));
    dynamic deserializeJson = JsonConvert.DeserializeObject<dynamic>(json.Result);
     private void writeDataOnModelMusicUrl()
        {
            foreach (var part in deserializeJson["packs"]["category1"])
            {
                foreach (var elements in part)
                {
                    var url = elements["url"];
                    var name = elements["name"];
                    //I'm doing something
                }
            }
            
            foreach (var part in deserializeJson["packs"]["category2"])
            {
                foreach (var elements in part)
                {
                    var url = elements["url"];
                    var name = elements["name"];
                    //I'm doing something
                }
            }
        }
    
