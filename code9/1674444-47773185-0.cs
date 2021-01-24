    public class SiteInfo
    {
        public string Name {get;set;}
        public double Sum {get;set;}
    }
    SiteInfo[] sum = new SiteInfo[result.Sites.Count];
    for (int i = 0; i < m; i++)
    {
        SiteInfo si = new SiteInfo();
        for (int j = 0; j < result.Sites[i].Actual.Count; j++)
        {
            si.Sum += (double)result.Sites[i].Actual[j];
        }
        si.Name = result.Sites[i].SiteName;
        sum[i] = si;
    }
