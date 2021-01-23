    var query = from c in db.Commercials
                group c by c.ProductType into cgroup
                select new
                {
                    ProductType = cgroup.Key,
                    NumberOfSpectators = cgroup.SelectMany(c => c.Movie.Spectators
                         .Where(s => s.Age > 60)
                         .Select(s => s.Id)).Distinct()).Count()
                };
