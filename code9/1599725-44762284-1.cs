    public void ErrorTest()
    {
        using (ScraperSetupEntities context = new ScraperSetupEntities())
        {
            int collectionavg;
            string today = DateTime.Now.DayOfWeek.ToString();
            collectionavg = GetCollectionAvgFromDay(context, today);
        }
    }
