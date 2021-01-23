    using LinqKit;
    ...
    internal Expression<Func<Ef.Perk, Bll.Perk>> MapPerkPerk(string name)
    {
        // LinqKit requires expressions to be in variables
        var nameFilter = GetNameFilter(name);
        return Linq.Expr((Ef.Perk perk) => new Bll.Perk
        {
            Id = perk.PerkId,
            Name = perk.PerkName,
            Description = perk.PerkDescription,
            Owned = perk.Players.Any(p => nameFilter.Invoke(p)) 
        }).Expand();
    }
 
