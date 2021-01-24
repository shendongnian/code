    try
    {
        // ...
    }
    catch (System.Net.WebException ex)
    {
        if (ex.Status == System.Net.WebExceptionStatus.ConnectFailure)
        {
            // To use these 2 commented out returns, you need to change 
            // your method's return type to Task<IHttpActionResult>
            // return Content(System.Net.HttpStatusCode.ServiceUnavailable, "Unavilable.");
            // return StatusCode(System.Net.HttpStatusCode.ServiceUnavailable);
            return "Unavailable"
        }
    }
    catch(Exception ex)
    {
        // You could be here because something went wrong in your server,
        // or the server you called which was not caught by the catch above
        // because it was not WebException. Make sure to give it some 
        // thought.
        // You need to change 
        // your method's return type to Task<IHttpActionResult> or 
        // just return a string.
        return StatusCode(System.Net.HttpStatusCode.InternalServerError);
    }
