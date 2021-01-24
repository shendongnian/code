   	public static class RSSHelper
	{
		public static IEnumerable<SyndicationItem> GetLatestArticlesFromFeeds(List<string> feedList, short articlesToTake)
		{
			return GetLatestArticlesFromFeedsAsync(feedList, articlesToTake).Result;
		}
		private async static Task<IEnumerable<SyndicationItem>> GetLatestArticlesFromFeedsAsync(List<string> feedList, short articlesToTake)
		{
			List<Task<IEnumerable<SyndicationItem>>> TaskList = new List<Task<IEnumerable<SyndicationItem>>>();
			foreach (string Feed in feedList)
			{
				// Call and start a task to evaluate the RSS feeds
				Task<IEnumerable<SyndicationItem>> T = Task.FromResult(GetLatestArticlesFromFeed(Feed).Result);
				TaskList.Add(T);
			}
			var Results = await Task.WhenAll(TaskList);
			// Filter the not null results - on the balance of probabilities, we'll still get more than 7 results. 
			var ReturnList = Results.SelectMany(s => TaskList.Where(w => w.Result != null).SelectMany(z => z.Result).OrderByDescending(o => o.PublishDate)).Take(articlesToTake);
			return ReturnList;
		}
		private async static Task<IEnumerable<SyndicationItem>> GetLatestArticlesFromFeed(string feedURL)
		{
			// We're only accepting XML based feeds, so create an XML reader:
			try
			{
				XmlReader Reader = XmlReader.Create(feedURL);
				SyndicationFeed Feed = SyndicationFeed.Load(Reader);
				Reader.Close();
				return Feed.Items.OrderByDescending(o => o.PublishDate).Take(5);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
