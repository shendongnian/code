    using (HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK))
    {
      httpResponseMessage.Content = new StreamContent(stream);
      // ...
    }
