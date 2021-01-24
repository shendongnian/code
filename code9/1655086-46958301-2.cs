    [ValidateQueryParametersFilter("property")]
    [Route("api/furniture/{furnitureId}/{property?}")]
    public async Task<HttpResponseMessage> Delete([FromUri] string furnitureId, string property = null)
    {
                
        return Request.CreateResponse(HttpStatusCode.Accepted);
    }
