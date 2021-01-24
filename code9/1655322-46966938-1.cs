    GlobalResponseFilters.Add((req, res, responseDto) => 
    {
        if (responseDto is AuthenticateResponse authDto)
        {
            authDto.Meta = new Dictionary<string,string> { ... }
        }
    });
