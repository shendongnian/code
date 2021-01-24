    private static bool IsSoftNotFound(HttpRequestMessage request, HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            bool routingFailure;
            if (request.Properties.TryGetValue<bool>(HttpPropertyKeys.NoRouteMatched, out routingFailure)
                && routingFailure)
            {
                return true;
            }
        }
        return false;
    }
