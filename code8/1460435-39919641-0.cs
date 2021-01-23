    public IQueryable<Thing> GetCompleteThingsWhere
                                  (Expression<Func<BetSelection, bool>> conditions)
    {
        return this._dbContext.GetQuery<Stuff>().Where(e => e.Things.All(conditions))
                                                .Select(e => e.Things);
    }
