     public HttpResponseMessage getnames()
     {
          var name = list.Select(x=>x.name);
          HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, name);
          return response;
      }         
