    [Route("getcustomer")]
    [HttpGet]
    public Customer GetCustomer(int customerId)
    {    // as a test: only customer 1 exists
        if (customerId == 1)
        {
           
        };   
        else
        {
           throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
        }
    }
