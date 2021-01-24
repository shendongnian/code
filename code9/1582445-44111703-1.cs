    public override IHttpActionResult CreditCustomer() {
        //...
        var response = new HttpResponseMessage();
        //...
        return this.ResponseMessage(response);
        
    }
