    var arr = new NHibernateQueryableProxy<int>(Enumerable.Range(1, 10000).AsQueryable());
    var fluentQuery = arr.Where(x => x > 1 && x < 4321443)
                .Take(1000)
                .Skip(3)
                .Union(new[] { 4235, 24543, 52 })
                .GroupBy(x => x.ToString().Length)
                .ToFuture()
                .ToList();
    var linqQuery = (from n in arr
                        where n > 40 && n < 50
                        select n.ToString())
                        .ToFuture()
                        .ToList();
