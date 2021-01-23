            var Data = theselines.Select(l => new
            {
                id = l.Where(t => t.Contains("01")).FirstOrDefault(),
                Price = l.Where(t => t.Contains(",")).FirstOrDefault(),
                Firstname= l[0],
                lastname = l[1]
            });
