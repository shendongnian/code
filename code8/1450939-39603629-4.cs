    public IEnumerable<A> GetAll(string id)
    {
        var a = _ctx.A.Include(e => e.Bases)
            .Where(x => x.Id == id).ToList();
        var baseIds = a.SelectMany(e => e.Bases.OfType<ModelA.Base1>().Select(b => b.Id));
        db.Base.OfType<Base1>().Include(e => e.SomeClass)
            .Where(e => baseIds.Contains(e.Id)).Load();
        baseIds = a.SelectMany(e => e.Bases.OfType<Base3>().Select(b => b.Id));
        db.Base.OfType<Base3>().Include(e => e.SomeOtherClass)
            .Where(e => baseIds.Contains(e.Id)).Load();
        return a;
    }
