    [EnableQuery(PageSize = 100)]
    public IQueryable<Order> Get(ODataQueryOptions<Order> options)
    {
        return _OrderRepo.GetAll(CompanyID); //Assuming this returns an IQueryable
    }
