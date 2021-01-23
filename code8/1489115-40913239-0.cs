    var desiredValues = persons.Aggregate(
        new { All = 0, InRegion = 0 }, 
        (sum, person) => new
        {
            All = person.Date < dateTime2000 ? sum.All + 1 : sum.All,
            InRegion = person.Region == "M" ? sum.InRegion + 1 : sum.InRegion
        });
    var prio2000_TotalCount = desiredValues.All;
    var prio2000_RegionM_Count = desiredValues.InRegion;
