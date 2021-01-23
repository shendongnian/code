    void UpdateTornStats()
    {
        using (var webClient = new WebClient())
        {
            var json = new WebClient().DownloadString(ApiUrl);
            var list = JsonConvert.DeserializeObject<PlayerStatistics.Stats.RootObject>(json);
            Console.WriteLine(list.Count);
        }
    }
