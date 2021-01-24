    public IEnumerable<Site> GetSites()
    {
        using (TraxgoDB ctx = new TraxgoDB())
        {
            return ctx.Sites;
        }
    }
