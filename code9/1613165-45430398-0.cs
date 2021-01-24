            [HttpPost]
            [Route("{application}/{envName}/date/{offset}")]
            [ResponseType(typeof(DateInfo))]
            public async Task<IHttpActionResult> SetDateOffsetForEnvironmentName(string application, string envName, string offset)
            {
            }
