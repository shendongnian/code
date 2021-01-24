    var recipients = new Recipients()
    {
        Signers = new List<Signer>()
        {
             new Signer()
             {
                  Email = "recipientone@acme.com",
                  Name = "recipient one",
                  RecipientId = "1",
                  //RoutingOrder = "1",
                  Tabs = new Tabs()
                  {
                      SignHereTabs = new List<SignHere>()
                      {
                          new SignHere()
                          {
                            DocumentId = "1", XPosition = "100", YPosition = "300", PageNumber = "1"
                          }
                      }
                  }
             },
              new Signer()
             {
                  Email = "recipienttwo@acme.com",
                  Name = "recipient two",
                  RecipientId = "2",
                  //RoutingOrder = "2",
                  Tabs = new Tabs()
                  {
                      SignHereTabs = new List<SignHere>()
                      {
                          new SignHere()
                          {
                            DocumentId = "1", XPosition = "100", YPosition = "500", PageNumber = "1",
                          }
                      }
                  }
             }
        }
    }
