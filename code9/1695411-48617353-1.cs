    public IEnumerable<NewsTagsCommodityViewModel> ListAllNew()
    {
        var model = db.News.Where(s => s.Status)
                        .Select(s => new NewsTagsCommodityViewModel
                        {
                            News = s
                        }).ToList();
        model.ForEach(s => s.RelatedNews = GetRelated(s.News));
        return model.OrderByDescending(x => x.News.CreatedDate);
    }
