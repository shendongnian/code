    SystemsPerPlatform.AddRange(
        SelectedAssets.GroupBy
        (
           a => a.AdminOperator).Select
           (
               g => new PlatformStats()
               {
                   Name = g.Key, 
                   TotalSystems = g.Count()
               } 
           )
       );
