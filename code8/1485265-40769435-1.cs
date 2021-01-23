    T poco = await Policy
        .Handle<FlurlHttpException>(IsWorthRetrying)
        .WaitAndRetry(...)
        .ExecuteAsync(() => url
            .SetQueryParams(queryString)
            .SetClaimsToken()
            .GetJsonAsync<T>());
    private bool IsWorthRetrying(FlurlHttpException ex) {
        switch ((int)ex.Call.Response.StatusCode) {
            case 408:
            case 500:
            case 502:
            case 504:
                return true;
            default:
                return false;
        }
    }
