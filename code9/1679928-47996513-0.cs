    protected override bool TryGetEntitiesByKey(IEnumerable<string> keys, out IEnumerable<Trade> entities)
    {
      var keyDates = keys.Select(s => DateTime.ParseExact("yyyyMMdd")).ToList();
      return this.TryLoadBase(x => keyDates.Contains(EntityFunctions.TruncateTime(x.date)), out entities);
    }
