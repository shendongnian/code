    public IEnumerable<PriceQuote> BestQuote(int take = 0)
    {
        var q = Quotes.Where(x => x.TotalRepayable == MinPrice)
            .OrderBy(x => Guid.NewGuid())
            .ThenByDescending(x => x.ProductDetail.Product.IsSponsored);
        return take == 0 ? q : q.Take(take);
    }
