    var d1 = new DateTime(2015, 11, 12);
    var d2 = new DateTime(2015, 11, 15);
    var query=from p in Bannertables
              join q in BannerTrackings
              on p.BannerId equals q.BannerId
              where q.CreateDate>=d1 && q.CreateDate<=d2
              group q by new {p.BannerId,p.Name} into myTab
              select new { 
                           BannerId = myTab.Key.BannerId,
                           BannerName=myTab.Key.Name,
                           ImpressionCount = myTab.Sum( x=> x.ImpressionCount),
                           ClickCount = myTab.Sum(x => x.ClickCount)
                          };
