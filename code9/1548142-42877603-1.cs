    public List<BaseNews> GetAllNewsDetailsByLang(string lang)
    {
        var newsDetails = new List<BaseNews>();
        if (lang.Trim() == "EN")
        {
            newsDetails = context.EN_NewsDetails
                                 .Include(en_nd=>en_nd.BaseNews)
                                 .Where(en_nd=>en_nd.BaseNews.IsActive.HasValue 
                                            && en_nd.BaseNews.IsActive)
                                 .Select(en_nd=>en_nd.BaseNews)
                                 .ToList();
        else if (lang.Trim() == "HI")
        {
            newsDetails = context.HI_NewsDetails
                                 .Include(hi_nd=>hi_nd.BaseNews)
                                 .Where(hi_nd=>hi_nd.BaseNews.IsActive.HasValue  
                                            && hi_nd.BaseNews.IsActive)
                                 .Select(hi_nd=>hi_nd.BaseNews)
                                 .ToList();
        }
        return newsDetails;
    }
