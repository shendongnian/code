        public void CreateEnvelopeDuplicateRecipients()
        {
            string accountID = "";//Initialization code here.
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\temp\test.pdf");
            var envDef = new EnvelopeDefinition()
            {
                EmailSubject = "Envelope with CC & Signers",
                Status = "Sent",
                Documents = new List<Document>()
                {
                    new Document()
                    {
                        DocumentBase64 = System.Convert.ToBase64String(fileBytes),
                        Name = "Dummy",
                        DocumentId = "1"
                    }
                },
                Recipients = new Recipients()
                {
                    CarbonCopies = new List<CarbonCopy>()
                    {
                        new CarbonCopy()
                        {
                            Email = "janecc@acme.com",
                            Name = "jane cc",
                            RecipientId = "1",
                            RoutingOrder = "1"
                        },
                        new CarbonCopy()
                        {
                            Email = "janecc@acme.com",
                            Name = "jane cc",
                            RecipientId = "3",
                            RoutingOrder = "3"
                        },
                        new CarbonCopy()
                        {
                            Email = "janecc@acme.com",
                            Name = "jane cc",
                            RecipientId = "5",
                            RoutingOrder = "5"
                        }
                    },
                    Signers = new List<Signer>()
                    {
                         new Signer()
                         {
                              Email = "janedoe@acme.com",
                              Name = "jane doe",
                              RecipientId = "2",
                              RoutingOrder = "2",
                              Tabs = new Tabs()
                              {
                                  SignHereTabs = new List<SignHere>()
                                  {
                                      new SignHere()
                                      {
                                        DocumentId = "1", XPosition = "100", YPosition = "200", PageNumber = "1",
                                      }
                                  }
                              }
                         },
                          new Signer()
                         {
                              Email = "bobbydoe@acme.com",
                              Name = "bobbydoe Demo",
                              RecipientId = "4",
                              RoutingOrder = "4",
                              Tabs = new Tabs()
                              {
                                  SignHereTabs = new List<SignHere>()
                                  {
                                      new SignHere()
                                      {
                                        DocumentId = "1", XPosition = "100", YPosition = "300", PageNumber = "1",
                                      }
                                  }
                              }
                         }
                    }
                }
            };
            var envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountID, envDef);
            Console.WriteLine(envelopeSummary);
        }
