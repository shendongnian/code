           // GET api/User/5
        [ResponseType(typeof(UserModel))]
        [Route("api/UserApi/GetUser")]
        public IHttpActionResult GetUser(Guid id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(item);
            }
        }
        // GET api/User/5
        [ResponseType(typeof(TanentDocumentsModel))]
        [Route("api/UserApi/GetUserDocuments")]
        public IHttpActionResult GetUserDocuments(Guid id)
        {
            var item = repository.GetUserDocuments(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(item);
            }
        }
        // GET api/User/GetCities/5
        [ResponseType(typeof(CityModel))]
        [Route("api/UserApi/GetCities")]
        public IHttpActionResult GetCities(int id)
        {
            var item = repository.GetCities(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(item);
            }
        }
        // GET api/User/GetCities/5
        [ResponseType(typeof(StateModel))]
        [Route("api/UserApi/GetStates")]
        public IHttpActionResult GetStates(int id)
        {
            var item = repository.GetStates(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(item);
            }
        }
