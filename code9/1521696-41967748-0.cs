    var dates = dbBlog.Data
                Select(d => new 
                {
                     Month = d.Month.Substring(....),
                     Year  = d.Year.Substring(....)
                })
                .GroupBy(o => new { o.Month,o.Year})
                .Select(g => new BlogArchiveClass
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    Total = g.Count()
                })
                .OrderByDescending(a => a.Year)
                .ThenByDescending(a => a.Month)
                .ToList();
