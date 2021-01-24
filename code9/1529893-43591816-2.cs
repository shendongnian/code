     [Route("Report/GetReport/{folio}")]
            [SwaggerFileResponse(HttpStatusCode.OK, "File Response")]
            [HttpGet]
            public HttpResponseMessage ExportReport(string folio)
            {
    ...
