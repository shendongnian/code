        [Route("api/Foo/MyController/{id}")]
        public IHttpActionResult Get(int? id)
        {
            if (id.HasValue)
            {
               // get by id
            } 
            else
            {
               // get all
            }
        }
