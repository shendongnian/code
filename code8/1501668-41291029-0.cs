    var range1 = DateRange(new DateTime(2016, 9, 26), new DateTime(2017, 12, 31), TimeSpan.FromDays(1));    
    var range2 = DateRange(new DateTime(2016, 12, 1), new DateTime(2016, 12, 31), TimeSpan.FromDays(1));
    var result = range1.Select(x => new
                {
                    date = x,
                    price = 20
                })
                .Concat(
                    range2.Select(x => new
                    {
                        date = x,
                        price = 18
                    })
                )
                .GroupBy(x => x.date).Select(x => x.OrderBy(Y => Y.price).First())
                .ToList();
    var final = result.GroupSequenceWhile((x, y) => x.price == y.price)
                .Select(g => new { start = g.First().date, end = g.Last().date, price=g.First().price })
                .ToList();
    foreach(var r  in final)
    {
        Console.WriteLine(r.price + "$ " + r.start.ToString("MM/dd/yy") + " " + r.end.ToString("MM/dd/yy"));
    }
----
    20$ 09.26.16 11.30.16
    18$ 12.01.16 12.31.16
    20$ 01.01.17 12.31.17
