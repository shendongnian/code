    int[] httpStatusCodesWorthRetrying = { 408, 500, 502, 503, 504 };
    HttpResponseMessage response = Policy
        .Handle<HttpRequestException>() 
        .Or<OtherExceptions>() // add other exceptions if you find your call may throw them
        .OrResult<HttpResponseMessage>(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
        .WaitAndRetryAsync(new[] {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    })
        .ExecuteAsync(async () => {
           return await url
            .SetQueryParams(queryString)
            .SetClaimsToken()
            .GetAsync();
        } );
    T responseAsT = response.ReceiveJson<T>();
