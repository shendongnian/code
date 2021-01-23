    List<int> httpStatusCodesWorthRetrying = new List<int>(new[] {408, 500, 502, 503, 504});
    HttpResponseMessage response = await Policy
        .Handle<HttpRequestException>() 
        .Or<OtherExceptions>() // add other exceptions if you find your call may throw them, eg FlurlHttpException
        .OrResult<HttpResponseMessage>(r => httpStatusCodesWorthRetrying.Contains((int)r.StatusCode))
        .WaitAndRetryAsync(new[] {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    })
        .ExecuteAsync(() => 
           url
            .SetQueryParams(queryString)
            .SetClaimsToken()
            .GetAsync()
        );
    T responseAsT = await Task.FromResult(response).ReceiveJson<T>();
