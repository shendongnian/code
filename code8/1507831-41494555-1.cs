     var assets = SelectedAssets.GroupBy(a => a.AdminOperator)
     .Select
     (
        g => new PlatformStats()
        {
            Name = g.Key,
            TotalSystems = g.Count()
        }
     ).OrderByDescending(g => g.TotalSystems)
     .Take(30);
     foreach (var asset in assets)
     {
          SystemsPerPlatform.Add(asset);
     }
