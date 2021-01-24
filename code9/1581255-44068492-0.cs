    [HttpGet]
        [Route("same")]
        public IHttpActionResult get(int id)
        {
            return Ok();
        }
        [HttpDelete]
        [Route("same")]
        public IHttpActionResult delete(int id)
        {
            return Ok();
        }
