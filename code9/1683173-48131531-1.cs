    public List<GroupMerks> GetAllMerkenSortedByMerk(AutoCriteria criteria)
    {
        return GetFullyGraphedAutos()
            .Where(x => string.IsNullOrEmpty(criteria.Name))
            .GroupBy(x => x.HuidigeAutoType.Merk)
            .Select(x => new GroupMerks
            {
                Merk = x.Key,
                Owners = x.Select(s => new Owner
                {
                    Plate = s.Nummerplaat,
                    Name = s.HuidigeEigenaar.Achternaam
                })
            })
            .ToList();
    }
