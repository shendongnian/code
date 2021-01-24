    q = db.From<Sale>()
        .LeftJoin<Contact>((s, c) => s.SellerId == c.Id, db.JoinAlias("seller"))
        .LeftJoin<Contact>((s, c) => s.BuyerId == c.Id, db.JoinAlias("buyer"));
    var results = db.SelectMulti<Sale, Contact, Contact>(q, 
        new[] { "Sale.*", "buyer.*", "seller.*" })
    foreach (var result in results) 
    {
        Sale sale = result.Item1;
        Contact buyer = result.Item2;
        Contact seller = result.Item3;
    }
