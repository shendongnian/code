    public List<Rings> GetSpecificRings(List<Rings> rings)
    {
        var rtn = new List<Rings>();
        foreach (var r in rings)
        {
            if (r.Price < 300 && (r.Size == 12 || r.Size == 13))
            {
                rtn.Add(r);
            }
        }
        return rtn;
    }
