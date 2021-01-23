    [EnableQuery(PageSize = 100)]
    public IQueryable<Order> Get()
    {
        return _OrderRepo.GetAll(CompanyID); //Assuming this returns an IQueryable
    }
