    public IEnumerable<Employee> GetOrderedPrefered(IEnumerable<Employee> aList, string[] aNames)
    {
        if (aNames.Length == 0) return aList.OrderBy(a => a.Name).ToList();
        var lRes = new List<Employee>()
        {
            aList.FirstOrDefault(a => a.Name == aNames[0])
        };
        lRes.AddRange(
            GetOrderedPrefered(
                aList.Where(a => a.Name != aNames[0]),
                aNames.Where(a => a != aNames.First()
            ).ToArray()
        ));
        return lRes;
    }
