    public static IQueryable<Entity> OrderByDesc(this IQueryable<Entity> source)
    {
        return source.Select(x=> new 
        {
            x,
            Desc = (
                x.Enum == Enum.One ? "Desc One" 
                : x.Enum == Enum.Two ? "Desc Two" 
                ... and so on)
        })
        .OrderBy(x=>x.Desc)
        .Select(x=>x.x);
    }
    
