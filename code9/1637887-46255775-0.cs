    //Send the GET request asynchronously and retrieve the response as a string.
    Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
    string httpResponseBody = "";
    
    try
    {
        //Send the GET request
        httpResponse = await httpClient.GetAsync(requestUri);
        if(httpResponse.IsSuccessStatusCode) { /* Do something with it */ }
        else { /* Do fallback here */ }
    }
    catch (Exception ex)
    {
        httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
    }
