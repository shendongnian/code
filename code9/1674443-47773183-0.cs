    public class SiteData
    {
        public string Name {get;set;}
        public double Total {get;set;}
    }
    ....
    List<SiteData> summary = new List<SiteData>()
    for (int i = 0; i < m; i++)
    {
        SiteData aSite = new SiteData();
        aSite.Name = result.Sites[i].SiteName;
        aSite.Total = result.Sites[i].Actual.Sum();
        summary.Add(aSite);
    }
