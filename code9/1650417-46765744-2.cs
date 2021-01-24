    [HttpGet]
    [Route("students")]
    [SwaggerOperation(Tags = new[] { "Student" })]
    [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ResponseModel<IList<Student>>))]
    [SwaggerResponseExample(HttpStatusCode.OK, typeof(StudentResponseExample))]
    [SwaggerResponse(HttpStatusCode.InternalServerError)]
    public IHttpActionResult SearchStudent(long? SyncDate = null,int? OffSet = null,int? Limit = null)
        {
            // Use the variables now here
            .
            .
            .
    
        }
