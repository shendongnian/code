    [ODataRoute]
    [EnableQuery]
    public IHttpActionResult Get()
    {
        var returnResult = db.ContractTypes.ToArray();
        var result = Array.ConvertAll(returnResult, Mapper.Map<ContractTypeDto>);       
        return result;     
    }
