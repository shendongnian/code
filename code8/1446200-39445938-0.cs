    public List<NewsItem> GetNewsItems()
    {
        var newsXml = XDocument.Load("http://xxxxxxxx.nl/index.php?page=news");
    
        var newsItems = (from newsitem in newsXml.Descendants("newsitem")
                         select new NewsItem
                         {
                             Title = WebUtility.HtmlDecode(newsitem.Element("title").Value),
                             Message = newsitem.Element("message").Value,
                             Date = DateTime.ParseExact(newsitem.Element("date").Value, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture), // TODO better error handling
                             User = newsitem.Element("user").Value,
                             Replies = Convert.ToInt32(newsitem.Element("replies").Value),
                             Url = newsitem.Element("budgetgamingurl").Value,
                             Views = Convert.ToInt32(newsitem.Element("views").Value)
                         }).ToList();
    
        return newsItems;
    }
