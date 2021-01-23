    [HttpGet]
    public IHttpActionResult Get(string sortBy = "id", int page = 1, int pageSize = maxPageSize) {
        var query = new Query { SortParam = sortby, Page = page, PageSize = pageSize };
        var result = _queryDispatcher.Dispatch<Query, QueryResult>(query);
        return Ok(result);
    }
