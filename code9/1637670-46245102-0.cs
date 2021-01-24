    public List<Check> Checks
    {
        get
        {
            return this.TransactionItems?.OfType<Check>().ToList();
        }
    }
