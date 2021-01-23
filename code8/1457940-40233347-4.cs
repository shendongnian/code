     [HttpPost()]
     [Route("getMeSomeServerData")]
     public JsonNetResult GetMeSomeServerData(string someVar) {
       GenericRestResponse response = new GenericRestResponse();
       response.Error = false;
       // do somthing 
       return new JsonNetResult(response);
     }
