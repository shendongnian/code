    private IEnumerable<string> GetResult<T>(IEnumerable<T> list, string propName)
    {
        var retList = new List<string>();
        var prop = typeof (T).GetProperty(propName);
        if (prop == null)
            throw new Exception("Property not found");
        retList = list.Select(c => prop.GetValue(c).ToString()).ToList();
        return retList;
    }
