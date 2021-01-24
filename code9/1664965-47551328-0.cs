    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static dynamic Save(int id) {
        var statusCode = (int)System.Net.HttpStatusCode.NotFound;
        var response = HttpContext.Current.Response;
        response.StatusCode = statusCode;
        response.TrySkipIisCustomErrors = true; //<--
        return new {
            message = $"Couldn't find object with Id: {id}"
        };
    }
   
