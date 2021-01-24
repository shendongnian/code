    var queryable = db.MemberStats.Where(ms => ms.MemberId == User.Identity.GetUserId())
                    .GroupBy(n => EntityFunctions.TruncateTime(n.Commited))
                    .Select(g => new Data()
                        {
                             Date = g.Key,
                             Count = g.Count()
                        }
                    ).ToList();
