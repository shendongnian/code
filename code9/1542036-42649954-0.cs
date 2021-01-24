    var root = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<Dictionary<string, object>>>>(jsonMain);
    List<News> news = root["d"].Select(result => new News()
    {
       id = result["ID"] as string,
       Title = result["Title"] as string,
       Date = result["PublishingDate"] as string,
       Content = result["News"] as string
    }).ToList();
    return View(news);
