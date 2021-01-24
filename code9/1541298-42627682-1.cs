     if (Request.Method.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
     {
                    IHttpActionResult response;
                    HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.NotFound);
                    responseMsg.Content = new StringContent("Method doesn't support POST or whatever", System.Text.Encoding.UTF8, "text/html");
    
                    response = ResponseMessage(responseMsg);
                    return response;
     }
