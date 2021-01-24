    public static decimal GetAll(decimal number)
    {
        return db.Sigma_Tables.Where(x => x.Defect_Rate < number)
                              .Select(x => (decimal)x.Sigma_Value)
                              .DefaultIfEmpty() // we need it, if null selected
                              .Min();
    }
