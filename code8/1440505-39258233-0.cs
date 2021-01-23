    [HttpGet]
    [Route("{someGuid:guid}")]
    public HttpResponseMessage Get([FromUri] Guid? someGuid, [FromUri] int someInt)
    {
        var responseData = _someService.RecordSet.AsQueryable(); // or some base query or equivalent
        if (someGuid.HasValue)
        {
           responseData = responseData.Where(x=>x.guid == someGuid);
        }
        if (someInt.HasValue)
        {
           responseData = responseData.Where(x=>x.int == someInt);
        }
    
        return Request.ResponseMessageFromApiEntity(responseData);
    }
