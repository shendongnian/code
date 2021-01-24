    public HttpResponseMessage Get(){
      List<Product> result = new List<Product>();
          //bind data to list
      var formatter = new JsonMediaTypeFormatter();
      var json =formatter.SerializerSettings;
    
      json.ContractResolver = new ShouldSerializeContractResolver();
          
      return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
    }
