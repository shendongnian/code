        [SwaggerResponse(HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(BadRequestErrorMessageResult))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        public IHttpActionResult GetById(int id)
        {
            if (id > 0)
                return Ok(new int[] { 1, 2 });
            else if (id == 0)
                return NotFound();
            else
                return BadRequest("id must be greater than 0");
        }
