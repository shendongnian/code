    [HttpGet]
    public HttpResponseMessage Get()
    {
        var myobject = new OrderPackage();
        myobject.Shipper = "something here";
        myobject.ShippingMethod = "So jones said \" this is not right \"";
        myobject.TrackingId = "19199n99fuajf";
        myobject.Id = 1;
        var result = Utility.GenericFunctions.ToXml(myobject, myobject.GetType());
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
        return response;
    }
