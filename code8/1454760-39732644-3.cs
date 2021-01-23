    var d1 = new DateTime(2015, 11, 12);
    var d2 = new DateTime(2015, 11, 15);
    var query=from p in Bannertables
              join q in BannerTrackings
              on p.BannerId equals q.BannerId
              where q.CreateDate>=d1 && q.CreateDate<=d2
              group new{Banner=p,Tracking=q} by p.BannerId into myTab
              select new { 
                           BannerId = myTab.Key,
                           Bannername=myTab.Select(e=>e.Banner.Name).FirstOrDefault(),
                           ImpressionCount = myTab.Sum( x=> x.Tracking.ImpressionCount),
                           ClickCount = myTab.Sum(x => x.Tracking.ClickCount)
                          };
