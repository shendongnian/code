    public IEnumerable<GroupedObject> FilterObjectsByAccess(IEnumerable<GroupedObject> source, bool allowAccess)
    {
        return source
                     .Select(i => new GroupedObject()
                     {
                         Name = i.Name,
                         List = i.List.Where(c => c.AllowedAccess == allowAccess).ToList()
                     })
                     .Where(z => z.List.Any());
    }
