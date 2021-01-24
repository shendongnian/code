    //PUT Customers/10/Search
    [HttpPut]
    [Route("Customers/{CustomerId:long}/Search", Name = "CustomerSearch")]
    [ResponseType(typeof(SearchResults))]
    public async Task<IHttpActionResult> Search(long CustomerId, [FromBody]SearchFilters filters, ) {
        //This func searches for some subentity inside customers
    }
    //GET Customers/Search    
    //GET Customers/Search/keyword
    [HttpGet]
    [Route("Customers/Search/{keyword?}", Name = "GetCustomersByKeyword")]
    public async Task<IHttpActionResult> SearchCustomers(string keyword = "") {
        //This func searches for customers based on the keyword in the customer name
    }
