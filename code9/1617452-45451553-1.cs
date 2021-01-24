    [HttpGet]
    [AllowAnonymous]
    public async Task<TDTO[]> GetList([FromQuery] QueryParameter query) {
        var queryOptions = new QueryOptions {
            Parameters = new [] { query }
        };
        return await this._service.GetList(queryOptions);
    }
