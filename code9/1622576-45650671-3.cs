    public IEnumerable<GroupedObject> FilterObjectsByAccess(IEnumerable<GroupedObject> source, bool allowAccess)
    {
        return source
                     .Select(i => new GroupedObject()
                     {
                         Name = i.Name,
                         List = i.List.Where(c => c.AllowedAccess == allowAccess).ToList()  // `ToList` here is optional - it is a trade-off between RAM and CPU
                     })
                     .Where(z => z.List.Any());
    }
