        if (!reply.Headers.Action.StartsWith("your actin here", StringComparison.Ordinal)) return;
        //get the string value for desired response code
        string statusCodeString = reply.Headers.Action.Substring(17);
        //convert to int
        int statusCodeInt;
        if (!int.TryParse(statusCodeString, out statusCodeInt)) return;
 
        //cast to HttpStatusCode
        System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        try
        {
            statusCode = (System.Net.HttpStatusCode)statusCodeInt;
        }
        catch (Exception ex)
        {
            return;
        }
 
        // Here the response code is changed
        reply.Properties[HttpResponseMessageProperty.Name] = new HttpResponseMessageProperty() { StatusCode = statusCode };
    }
}                                              
           }
    wich is called after the operation  has returned but before the reply message is sent 
