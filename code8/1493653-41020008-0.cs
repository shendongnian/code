    public static IEnumerable<TEnitity> In<TEnitity, TMember>(
        this IEnumerable<TEnitity> source, 
        Func<TEnitity, TMember> projector, IEnumerable<TMember> validCases)
    {
        var validSet = new HashSet<TMember>(validCases);
        return source.Where(s => validSet.Contains(projector(s)));
    }
