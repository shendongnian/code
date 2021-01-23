    private EquivalencyAssertionOptions<AssetCenterSimCard> ExcludeProperties(EquivalencyAssertionOptions<AssetCenterSimCard> options)
    {
            options.Excluding(t => t.CeOperator);
            options.Excluding(t => t.CeOperatorName);
            options.Excluding(t => t.Status);
            options.Excluding(t => t.IsOperational);
            return options;
    }
