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
        Console.WriteLine(r.price + "$ " + r.start.ToString("MM/dd/yy", CultureInfo.InvariantCulture) + " " + r.end.ToString("MM/dd/yy", CultureInfo.InvariantCulture));
    }
