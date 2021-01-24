    var v = ctx.Items
        .Where(x =>
            x.userid == user.userid &&
            (filterWord == "" || x.Title.ToLower().Contains(filterWord.ToLower())))
        .Select(e => new MyViewModel
        {
            Title = e.Title,
            CurrentPrice = e.CurrentPrice.Value,
            ItemID = e.ItemID.ToString(),
            Sales = e.Transactions
                .Where(p => 
                    p.TransactionDate >= intoPast && 
                    p.TransactionDate <= endDate)
                .Sum(x => x.QuantityPurchased)
        })
        .Where(x => x.Sales > 0);
