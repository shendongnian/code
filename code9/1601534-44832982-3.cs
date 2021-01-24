    [HttpGet]
    public IEnumerable<Facility> Facilities(int pageNumber, int pageSize)
    {
        string jsondata = Data.GetFacilities;
        JArray a = JArray.Parse(jsondata);
        return a.Skip(pageNumber * pageSize).Take(pageSize).Select(x => x.ToObject<Facility>());
    }
