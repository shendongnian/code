    public static class HttpRequestExtension
    {
      public static async Task<SearchParams> GetSearchParams(this HttpRequest request)
            {
                var parameters = await request.TupledParameters();
    
                try
                {
                    for (var i = 0; i < parameters.Count; i++)
                    {
                        if (parameters[i].Item1 == "_count" && parameters[i].Item2 == "0")
                        {
                            parameters[i] = new Tuple<string, string>("_summary", "count");
                        }
                    }
                    var searchCommand = SearchParams.FromUriParamList(parameters);
                    return searchCommand;
                }
                catch (FormatException formatException)
                {
                    throw new FhirException(formatException.Message, OperationOutcome.IssueType.Invalid, OperationOutcome.IssueSeverity.Fatal, HttpStatusCode.BadRequest);
                }
            }
 
    public static async Task<List<Tuple<string, string>>> TupledParameters(this HttpRequest request)
    {
            var list = new List<Tuple<string, string>>();
  
            var query = request.Query;
            foreach (var pair in query)
            {
                list.Add(new Tuple<string, string>(pair.Key, pair.Value));
            }
            if (!request.HasFormContentType)
            {
                return list;
            }
            var getContent = await request.ReadFormAsync();
            if (getContent == null)
            {
                return list;
            }
            foreach (var key in getContent.Keys)
            {
                if (!getContent.TryGetValue(key, out StringValues values))
                {
                    continue;
                }
                foreach (var value in values)
                {
                    list.Add(new Tuple<string, string>(key, value));
                }
            }
            return list;
        }
    }
