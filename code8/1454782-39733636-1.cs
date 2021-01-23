    public static IEnumerable FilterRings(IEnumerable<Rings> RingList, decimal price, string maker /* etc.......*/)
    {
        return ringList.Where(r => r.Price <= price /* or > or == or whatever*/)
                       .Where(r => r.Maker == maker);
                     //.Where etc.. etc...
    }
