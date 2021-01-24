    public SomeApiController : ApiController
    {
        public IHttpActionResult MyAction()
        {
            var requestCount = Request.GetSessionProperty<int>("RequestCount");
    
            Request.SetSessionProperty("RequestCount", ++requestCount);
        }
    }
