    [NotMapped]
    public List<string> topLevelDomain
    {
        get => Deserialize(TopLevelDomainString);
        set => TopLevelDomainString = Serialize(value);
    }
    public string TopLevelDomainString { get; set; }
