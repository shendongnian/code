    [NotMapped]
    public BigInteger ReputationValue { get; set; }
    
    public string Reputation
    {
        get
        {
            return ReputationValue.ToString();
        }
        set
        {
            ReputationValue = BigInteger.Parse(value);
        }
    }
