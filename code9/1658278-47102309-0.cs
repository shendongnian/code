    PreRequestFilters.Add((req, res) =>
    {
        if (req.PathInfo.StartsWith("/metadata") || req.PathInfo.StartsWith("/swagger-ui"))
        {
            var session = req.GetSession();
            if (!session.IsAuthenticated)
            {
                res.StatusCode = (int)HttpStatusCode.Unauthorized;
                res.EndRequest();
            }
        }
    });
