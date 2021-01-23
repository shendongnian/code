    public IEnumerable<A> GetAll(string id)
    {
        var a = _ctx.A.Where(x => x.Id == id).ToList();
        _ctx.Base.OfType<Base1>().Include(e => e.SomeClass).Where(e => e.A.Id == id).Load();
        _ctx.Base.OfType<Base3>().Include(e => e.SomeOtherClass).Where(e => e.A.Id == id).Load();
        return a;
    }
