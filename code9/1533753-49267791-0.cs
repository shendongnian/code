    _mockProviderService
      .Given("There is a something with id 'tester'")
      .UponReceiving("A GET request to retrieve the something")
      .With(new ProviderServiceRequest
      {
        Method = HttpVerb.Get,
        Path = "/somethings/tester",
        Headers = new Dictionary<string, object>
        {
          { "Accept", "application/json" }
        }
      })
