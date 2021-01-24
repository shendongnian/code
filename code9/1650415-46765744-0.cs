    [HttpGet]
    [Route("students")]
    [SwaggerOperation(Tags = new[] { "Student" })]
    [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ResponseModel<IList<Student>>))]
    [SwaggerResponseExample(HttpStatusCode.OK, typeof(StudentResponseExample))]
    [SwaggerResponse(HttpStatusCode.InternalServerError)]
    public IHttpActionResult SearchStudent(long? SyncDate,int? OffSet,int? Limit)
        {
            // Use the variables now here
            .
            .
            .
    
        }
