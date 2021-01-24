     public IEnumerable<NewsTagsCommodityViewModel> ListAllNews()
     {
            var model = db.News.Where(s => s.Status)
                            .Select(s => new NewsTagsCommodityViewModel
                            {
                                News = s,
                                RelatedNews = GetRelated(s)
                            });
            return model.OrderByDescending(x => x.News.CreatedDate);
     }
