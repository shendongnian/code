    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static dynamic Save(int id) {
        //...
        //if we get this far return not found.
        return NotFound($"Couldn't find object with Id: {id}");
    }
    private static object NotFound(string message) {
        var statusCode = (int)System.Net.HttpStatusCode.NotFound;
        var response = HttpContext.Current.Response;
        response.StatusCode = statusCode;
        response.TrySkipIisCustomErrors = true; //<--
        return new {
            message = message
        };
    }
