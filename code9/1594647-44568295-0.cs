     var area = db.MyDbSet
                        .Where(s => s.langid == langid)
                        .GroupBy(s => s.Title)
                        .Select(g => new { Title = g.Key, CodeId = g.FirstOrDefault().CodeId })
                        .Select(s => new { s.Title , s.CodeId });
