    this.GlobalRequestFilters.Add((req, res, requestDto) => {
        var auth = req.Headers[HttpHeaders.Authorization];
        if (auth == null)
        {
            res.StatusCode = (int)HttpStatusCode.Unauthorized;
            res.EndRequest();
        }
        else if (!MyIsValid(auth))
        {
            res.StatusCode = (int)HttpStatusCode.Forbidden;
            res.EndRequest();
        }
    });
