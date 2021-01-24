    var httpRepsonseMessage = new HttpResponseMessage(HttpStatusCode.OK);
    httpResponseMessage.Content = new StreamContent(stream);
    try
    {
       // ...
    }
    finally
    {
      httpResponseMessage.Dispose();
    }
