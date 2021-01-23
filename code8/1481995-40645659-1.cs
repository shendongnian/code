    [HttpGet]
    [CustomExceptionFilterAttribute]
    public HttpResponseMessage Getdetails(string id, DateTime date_in)
    {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            //...
    }
