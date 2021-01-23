    public IEnumerable<PriceQuote> BestQuote(int take = 0)
    {
        var q = Quotes.Where(x => x.TotalRepayable == MinPrice)
            .OrderBy(x => x.ProductDetail.Product.IsSponsored)
            .ThenByDescending(x => Guid.NewGuid());
        return take == 0 ? q : q.Take(take);
    }
