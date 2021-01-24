    [HttpPost]
    public HttpResponseMessage PostCustomer([FromBody]Customer customer)
    {
       System.Diagnostics.Debug.WriteLine(customer);
    }
