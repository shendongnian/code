            [Route("api/test")]
            public HttpResponseMessage Get()
            {
                HttpResponseMessage response = null;
                List<table_name> obj = new List<table_name>();
                try
                {
                    obj = db.table_name.AsNoTracking().ToList();
    
                    response = Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return response;
            }
