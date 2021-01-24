    public static IEnumerable<Vendor> LoadVendors()
    {
        var vendors =
            File.ReadAllLines("Vendor.txt").Select(x => x.Split(','))
                .Select(x =>
                new Vendor
                {
                    Name = x[1],
                    City = x[3],
                    State = x[4],
                    ZipCode = x[5],
                    Phone = x[6]
                }).ToList();
    
        return vendors;
    }
