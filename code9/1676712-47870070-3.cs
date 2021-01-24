     var optimised = from o in accesses
                     group o by new { o.userid, o.FeatureName } into g
                     select new Access()
                     {
                         userid = g.Key.userid,
                         FeatureName = g.Key.FeatureName,
                         //OrderByDescending put the true before the false
                         Accessible = g.OrderByDescending(t => t.Accessible).First().Accessible,
                         //you might want to comment the accessid and roleid
                         accessid = g.First().accessid,
                         roleid = g.First().roleid,
                     };
