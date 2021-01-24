    // Main DTO...
    public TerritoryAndCountyOptions TerritoryAndCountyOptions { get; set; }
    public string CountyName => TerritoryAndCountyOptions?.CountyName;
    // Mapping for main object
    .ForMember(d => d.TerritoryAndCountyOptions, o => o.MapFrom(x => x.TerritoryAndCounty.Options.OrderByDescending(y => y.Selected).FirstOrDefault())
