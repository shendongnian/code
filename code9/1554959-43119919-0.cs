    public IEnumerable<FooDupeCheckModel> MatchExists(IEnumerable<FooDupeCheckModel> matches)
    {
        //Convert small set to check for dups to objects recognized by the EF
        var fooMatches = matches.Select(m => new Foo() { BarId = m.BardId, BatId = m.BatId });
    
        //This should now work
        return _db.Foos
                  .Where(f => fooMatches.Any(m => m.BarId == f.BarId &&
                                               m.BatId == f.BatId))
                  .Select(f => new FooDupeCheckModel
                  {
                      BarId = f.BarId,
                      BatId = f.BatId
                  });
    }
