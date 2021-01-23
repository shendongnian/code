    public IQueryable<Thing> GetCompleteThingsWhere
                                  (Expression<Func<BetSelection, bool>> conditions)
    {
        var filteredThings = base.Filter(conjunction)
                               .Select(thing => new { thing.StuffId, thing.ThingId})
                               .ToArray();
    
        var filteredThingsStuffIds = filteredThings
                                        .Select(arg => arg.StuffId)
                                        .Distinct()
                                        .ToArray();
        var filteredThingsThingIds = filteredThings
                                        .Select(arg => arg.ThingId)
                                        .Distinct()
                                        .ToArray();
    
        var allThings = this.GetAll();
    
        var allThingsForFilteredBets =
            allThings.Where(x => filteredThingsStuffIds.Contains(x.StuffId));
    
        var missingThingsFromFilteredThingsStuffIds =
            allThingsForFilteredBets.Where(x => !filteredThingsThingIds.Contains(x.ThingId))
                                    .Select(thing => thing.StuffId)
                                    .ToArray();
    
        var completeBets =
            allThingsForFilteredBets
                   .Where(x => !missingThingsFromFilteredThingsStuffIds.Contains(x.StuffId));
    
        return completeBets;
    }
