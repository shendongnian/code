    // ...
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<MyDataType>>> getMyData(int pageSize = 20,
                                                                           int pageNumber = 0)
    {
        return await _context.myData.AsNoTracking().paginate(pageSize, pageNumber);
    }
    // ...
