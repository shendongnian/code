    [HttpGet]
    [Route("customers/{customerNumber}")]
    public virtual IHttpActionResult Get([FromUri] CustomerNumber customerNumber)
    {
        var customerEntitiesList = _tableStorageService.GetCustomerEntities(customerNumber);
        var customersList = customerEntitiesList.Select(customerEntity => customerEntity.PartitionKey).ToList();
        if (customersList.Any()) {
            return Ok(customersList);
        }
        return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No content found.");
    }
