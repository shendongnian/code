    public static class HttpRequestExtensions
    {
      public static IActionResult CreateResponse(this HttpRequest request, int status, object content)
      {
        return new ObjectResult(content)
        {
          StatusCode = status
        };
      }
    }
