    public IList<IList<string>> ExecuteQuery(string ids, string metrics, string dimensions, DateTime startDate, DateTime endDate) 
    {
         var formattedStartDate = startDate.Value.ToString("yyyy-MM-dd");
         var formattedEndDate = endDate.Value.ToString("yyyy-MM-dd");
         var request = _analyticsService.Get(ids, formattedStartDate, formattedEndDate, metrics);
         request.Dimensions = dimensions;
         request.MaxResults = 10000;
         request.SamplingLevel = GetRequest.SamplingLevelEnum.HIGHERPRECISION;
    
         var result = new List<IList<string>>();
         var response = request.Execute();
         result.AddRange(response.Rows);
         return result;
    }
    ...
    var data = ExecuteQuery(ids, "ga:users", "ga:pagePath", startDate, endDate);
