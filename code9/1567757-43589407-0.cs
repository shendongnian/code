    var user = ctx.Users.FirstOrDefault(x => x.Username== username);
    
    ViewBag.Items = user.Items.GroupBy(x => x.ItemId).Select(pr => new SalesViewModel
    {
       ImageURL = pr.ImageURL,
       Title= pr.Title,
       Sales = pr.Transactions.Sum(y=>y.QuantitySold)
    })
    .OrderByDescending(x=>x.Sales)
    .ToList();
