    public async Task<IHttpActionResult> GetAccount(string query) {
        //get the query response NOTE: assuming it is HttpResponseMessage
        var queryResponse = await Client.Instance.GetAsync(Client.Instance.BaseAddress + query);
        //get the status code for pass through
        var queryResponseStatus = queryResponse.StatusCode;
        //content to be passed on in the response
        var jsonString = await queryResponse.Content.ReadAsStringAsync();
        //create response message with status code
        var responseMessage = Request.CreateResponse(queryResponseStatus);
        //assign the content of the response
        responseMessage.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        //return the result
        return ResponseMessage(responseMessage);
    }
