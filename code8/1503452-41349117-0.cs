    [HttpPut]
    public HttpResponseMessage MyPutMethod()
    {
    try
    {
    ...process
    return Request.CreateResponse(HttpStatusCode.OK, "Success");
    }
    catch (Exception ex)
    {
    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
