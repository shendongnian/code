    var test = JsonConvert.DeserializeObject<RootObject>(json);
    Dictionary<string, dynamic> mediaCampaigns = new Dictionary<string, dynamic>();
    foreach (var item in test.results)
    {
        mediaCampaigns.Add(item.metadata.fromDate, new 
        {
            cost = item.metrics.spend,
            clicks = item.metrics.clicks,
            impressions = item.metrics.impressions,
            conversions = item.metrics.conversions
        });
    }
