    var query= db.Feedback
                    .GroupBy(f => f.Name, (f, g) => new
                    {
                        Name = f,
                        Comment = g.Select(h => h.Comment),
                        Date= g.Select(h => h.Date)
                    })
                    .OrderByDescending(f => f.Date).FirstOrDefault();
