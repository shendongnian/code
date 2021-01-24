    var user = ctx.Users.FirstOrDefault(x => x.Username== username);
    ViewBag.Items = user.Items.GroupBy(x => x.ItemId).Select(pr => new SalesViewModel
    {
        ImageURL = pr.FirstOrDefault(x=>x.ImageURL),
        Title= pr.FirstOrDefault(x=>x.Title),
        Sales = pr.FirstOrDefault(x=>x.Transactions.Sum(y=>y.QuantitySold))
    })
    .OrderByDescending(x=>x.Sales)
    .ToList();
