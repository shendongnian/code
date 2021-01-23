         var x = list.Where(w => w.Property1 != 1)
                .GroupBy(t => new {ID = t.UserId})
                .Select(w => new
                {
                    average = w.Average(a => a.Testval),
                    count = w.Count()
                }).Single();
