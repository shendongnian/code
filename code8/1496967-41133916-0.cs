    // First check if this query will return any results 
    var records =
        raptorDS.Tables[RaptorTable.DurationContribBySector].AsEnumerable().Where(r =>
        r.Field<string>(RaptorColumns.FundCode) == fundDescriptionColumn &&
        r.Field<string>(RaptorColumns.Component) == Component.B8_DURATION_CONTRIBUTION_BY_SECTOR &&
        r.Field<string>(RaptorColumns.Sector) == "Spread Duration--IR Swap");
    
    // CHeck if any result
    if (records.Any())
    {
        // We have results so let's go through each record and try to get that value
        // converted to a double
        List<double> values = new List<double>();
        List<string> badValues = new List<string>();
        foreach (var thisRecord in records)
        {
            var fsdc = thisRecord.Field<string>(RaptorColumns.FundSpreadDurationContribution);
            if (!string.IsNullOrWhiteSpace(fsdc))
            {
                double val = 0;
                if (double.TryParse(fsdc, val))
                {
                    values.Add(val);
                }
                else
                {
                    badValues.Add(fsdc);
                }
            }
        }
    
        // Do whatever you need to do with values here
    
        // and bad values here
    }
