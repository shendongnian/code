    public object GetRestrictLookupInfo(IEnumerable<int> lookupCombinations)
    {
        List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
        if (lookupCombinations.Contains(1))
        {
            var tmp = _unitOfWork.GetRepository<Item>()
                                 .ListAll()
                                 .Select(x => new
                                 {
                                     itemId = x.Id,
                                     itemName = x.Name
                                 })
                                 .Select(x => 
                                 {
                                     var dic = new Dictionary<string, object>();
                                     dic.Add(nameof(x.itemId), x.itemId);
                                     dic.Add(nameof(x.itemName), x.itemName);
                                     return dic;
                                 });
            result.AddRange(tmp);
        }
        if (lookupCombinations.Contains(2))
        {
            var tmp = _unitOfWork.GetRepository<Venue>()
                                 .ListAll()
                                 .Select(x => new
                                 {
                                     locationName = x.Address.City,
                                     venueId = x.VenueId,
                                     venueName = x.Name
                                 })
                                 .Select(x => 
                                 {
                                     var dic = new Dictionary<string, object>();
                                     dic.Add(nameof(x.locationName), x.locationName);
                                     dic.Add(nameof(x.venueId), x.venueId);
                                     dic.Add(nameof(x.venueName), x.venueName);
                                     return dic;
                                 });
            result = result.SelectMany(r => tmp.Select(t => r.Concat(t)));
        }
        return result;
    }
