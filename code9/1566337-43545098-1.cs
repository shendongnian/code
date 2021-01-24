    public IList<Entity> SearchRange(string lower, string upper)
    {
        return _session
            .CreateQuery("from Entity e where e.Name between :lower and :upper")
            .SetString("lower", lower)
            .SetString("upper", upper)
            .List<Entity>();
    }
