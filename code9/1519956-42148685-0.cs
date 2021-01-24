    [HttpGet, Route("getPagedData")]
    public PageResult<MyEFClassToFilterOn> GetPagedData(ODataQueryOptions opts)
    {
         using (var db = new dbEntities())
         {
            var myQueryable = _searchRepo.GetBatchQueryable(db);
            var myFilteredQueryable = opts.ApplyTo(myQueryable.AsQueryable()) as IQueryable<MyEFClassToFilterOn>;
            var result = myFilteredQueryable.ToList();
            var rowcount = result.Count();
            return new PageResult<MyEFClassToFilterOn>(emailBatch, null, rowcount);
         }
    }
