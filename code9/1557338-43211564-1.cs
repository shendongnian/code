    public static class RSSHelper
    {
        public static IEnumerable<SyndicationItem> GetLatestArticlesFromFeeds(List<string> feedList, short articlesToTake)
        {
            return feedList.SelectMany(f => GetLatestArticlesFromFeed(f)).OrderByDescending(a => a.PublishDate).Take(articlesToTake);
        }
    
        private static IEnumerable<SyndicationItem> GetLatestArticlesFromFeed(string feedURL)
        {
            // We're only accepting XML based feeds, so create an XML reader:
    
            SyndicationFeed feed = null;
    
            try
            {
                using (XmlReader reader = XmlReader.Create(feedURL))
                {
                     feed = SyndicationFeed.Load(reader);
                }
                return feed.Items.OrderByDescending(o => o.PublishDate).Take(5);
            }
            catch
            {
                return Enumerable.Empty<SyndicationItem>();
            }          
        }
    }
