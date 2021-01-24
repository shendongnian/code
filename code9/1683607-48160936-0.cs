    var q = db.From<Sale>()
        .LeftJoin<Contact>((s,c) => s.SellerId == c.Id, db.JoinAlias("seller"))
        .LeftJoin<Contact>((s,c) => s.BuyerId == c.Id, db.JoinAlias("buyer"))
        .Select<Sale, Contact>((s,c) => new {
            s,
            BuyerFirstName = Sql.JoinAlias(c.FirstName, "buyer"),
            BuyerLastName = Sql.JoinAlias(c.LastName, "buyer"),
            SellerFirstName = Sql.JoinAlias(c.FirstName, "seller"),
            SellerLastName = Sql.JoinAlias(c.LastName, "seller"),
        });
