    public IQueryable<Thing> GetCompleteThingsWhere
                                  (Expression<Func<BetSelection, bool>> conditions)
    {
        return this._dbContext.GetQuery<StuffThing>()
                              .GroupBy(e => e.StuffId) // Denormalize
                              .Where(g => g.All(conditions))
                              .SelectMany(g => g);
    }
