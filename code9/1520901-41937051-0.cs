        return filter
				.Group(
					r => new
					{
						groupedYear = r.PublishedDate.Year,
						groupedMonth = r.PublishedDate.Month,
						groupedDay = r.PublishedDate.Day,
						itemId = r.ItemId,
					},
					g => new
					{
						Key = g.Key,
						RetweetsValue = g.First().SocialData
					})
				.Project(
					r => new 
					{
						SocialMedia = r.RetweetsValue,
						Day = r.Key.groupedDay,
						Month = r.Key.groupedMonth,
						Year = r.Key.groupedYear,
					})
				.ToList()				
                .Select(
				r => new ChartSummary
				{
					SocialMedia = r.SocialMedia.FirstOrDefault(x=>x.Key=="Retweets").Value,
					Day = r.Day,
					Month = r.Month,
					Year = r.Year
				});
