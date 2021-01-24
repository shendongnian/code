        [System.Web.Http.HttpGet]
		[System.Web.Http.Route("GetByName")]
		public IEnumerable<Logs> GetByName(string loggername)
        {
			var log = _repository.GetLogsByName(loggername);
            if (log == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return log;
            }
        }
