    using (HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
    {
      Content = new StreamContent(stream)
    })
    {
      // ...
    }
