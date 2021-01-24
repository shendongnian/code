    var movies = (from m in ctx.checkouts
                          select new
                          {
                              MovieID = m.MovieID,
                              SubscriberID = m.SubscriberID,
                              DueDate = m.DueDate,
                              // Computed Column is line below
                              IsOverDue = (m.DueDate > DateTime.Now) ? "NO" : "YES"
                          }).ToList();
