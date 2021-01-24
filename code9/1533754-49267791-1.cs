     .WillRespondWith(new ProviderServiceResponse
      {
        Status = 200,
        Headers = new Dictionary<string, object>
        {
          { "Content-Type", "application/json; charset=utf-8" }
        },
        Body = new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
        {
          id = "tester",
          firstName = "Totally",
          lastName = "Awesome"
        }
      }); //NOTE: WillRespondWith call must come last as it will register the interaction
