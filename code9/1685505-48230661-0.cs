    IQueryable<Partner> partners; // use the same type as ctx.Partners has
    if (smithsOnly)
        partners = ctx.Partners.Where(x => x.LastName == "Smith");
    else
        partners = ctx.Partners;
    var list = partners.ToList();
