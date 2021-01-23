    List<PromoResult> promoResult = new List<PromoResult>()
    {
        new PromoResult() {  PromoPrice=20, StartDate = new DateTime(2016, 9, 26),EndDate=new DateTime(2017, 12, 31)},
        new PromoResult() {  PromoPrice=18, StartDate = new DateTime(2016, 12, 1),EndDate=new DateTime(2016, 12, 31)}
    };
    var result = promoResult.SelectMany(x => DateRange(x.StartDate, x.EndDate, TimeSpan.FromDays(1))
                                                        .Select(y => new { promo = x, date = y }))
                    .GroupBy(x => x.date).Select(x => x.OrderBy(y => y.promo.PromoPrice).First())
                    .OrderBy(x=>x.date)
                    .ToList();
    var final = result.GroupSequenceWhile((x, y) => x.promo.PromoPrice == y.promo.PromoPrice)
                .Select(g => new { start = g.First().date, end = g.Last().date, price = g.First().promo.PromoPrice })
                .ToList();
    foreach (var r in final)
    {
        Console.WriteLine(r.price + "$ " + r.start.ToString("MM/dd/yy", CultureInfo.InvariantCulture) + " " + r.end.ToString("MM/dd/yy", CultureInfo.InvariantCulture));
    }
