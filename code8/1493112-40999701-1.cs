       var newItems = (from story in xml.Root.EnumerateChildren("item")
                        select new Feed
                        {
                            Title = ((string)story.GetChild("title")),
                            Link = ((string)story.GetChild("link")),
                            Description = ((string)story.GetChild("description")),
                            PublishDate = ((string)story.GetChild("pubDate")),
                        }).Take(20).ToList();
