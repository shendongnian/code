    // set variables
    int numberOfRankedItems;
    if (queryData.NumberOfRankedItems != null)
    {
        numberOfRankedItems = (int) queryData.NumberOfRankedItems;
    } else
    {
        numberOfRankedItems = 0;
    }
    string minMaxChoice = queryData.MinMaxChoice;
    string minMaxFeatureColumnName = queryData.MinMaxFeatureColumnName;
    
    string orderByPrompt = "";
    if (minMaxChoice == "max")
    {
        orderByPrompt = "it.Sum(POSITIONVALUE) descending";
    } else if (minMaxChoice == "min")
    {
        orderByPrompt = "it.Sum(POSITIONVALUE) ascending";
    }
    
    string groupByPrompt = queryData.MinMaxFeatureColumnName;
    
    // execute query
    IQueryable query = (from tableRow in Context.xxx
                            where /* some filters */
                            select tableRow).
                            GroupBy(groupByPrompt, "it").
                            OrderBy(orderByPrompt).
                            Select("new (it.Key as minMaxFeature, it.Sum(POSITIONVALUE) as sumPosition)").
                            Take(numberOfRankedItems);
    
    // create response dictionary
    Dictionary<int?, Dictionary<string, int?>> response = new Dictionary<int?, Dictionary<string, int?>>();
    int count = 1;
    foreach (dynamic item in query)
    {
        string minMaxFeatureReturn = item.GetType().GetProperty("minMaxFeature").GetValue(item);
        int? sumPositionReturn = item.GetType().GetProperty("sumPosition").GetValue(item);
        response[count] = new Dictionary<string, int?>() { { minMaxFeatureReturn, sumPositionReturn } };
        count++;
    }            
    return response;
