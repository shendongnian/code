    public IEnumerable<GroupedObject> FilterObjectsByAccess(IEnumerable<GroupedObject> source, bool allowAccess)
    {
        return source.Where(i => i.List.Any(c => c.AllowedAccess == allowAccess))
                     .Select(i => new GroupedObject()
                     {
                         Name = i.Name,
                         List = i.List.Where(c => c.AllowedAccess == allowAccess)
                     });
    }
