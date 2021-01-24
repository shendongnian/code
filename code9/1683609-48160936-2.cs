    var q = db.From<Sale>()
        .LeftJoin<Contact>((s, c) => s.SellerId == c.Id, db.JoinAlias("seller"))
        .LeftJoin<Contact>((s, c) => s.BuyerId == c.Id, db.JoinAlias("buyer"))
        .Select("Sale.*, 0 EOT, buyer.*, 0 EOT, seller.*, 0 EOT");
    var results = db.Select<Tuple<Sale, ContactIssue, ContactIssue>>(q);
