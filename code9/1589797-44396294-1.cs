    public void CreateEnvelope()
	{
	  var envDef = new EnvelopeDefinition()
      {
          EmailSubject = "Envelope with multiple documents",
          Status = "sent",
          CompositeTemplates = new List<CompositeTemplate>()
      };
      
      for (int docNumber = 1; docNumber <= 10; docNumber++)
      {
		  var compostiteTemplate = BuildCompositeTemplate(docNumber.ToString());
          envDef.CompositeTemplates.Add(compostiteTemplate);
      
      }
      
      EnvelopesApi envelopesApi = new EnvelopesApi();
      EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);
      Console.WriteLine(envelopeSummary);
	}
	
	public CompositeTemplate BuildCompositeTemplate(string docNumber)
	{
		string serverTemplateId = "";//Add your server template ID here
		return new CompositeTemplate()
        {
              ServerTemplates = new List<ServerTemplate>()
              {
                  new ServerTemplate()
                  {
                      TemplateId = serverTemplateId,
                      Sequence = docNumber
                  }
              },
              InlineTemplates = new List<InlineTemplate>()
              {
                  new InlineTemplate()
                  {
                      Sequence = docNumber,
                      Recipients = new Recipients()
                      {
                          Signers = new List<Signer>()
                          {
                              new Signer()
                              {
                                  Email = "Janedoe@acme.com",
                                  Name = "Jane Doe",
                                  RecipientId = "1",
                                  RoleName = "Signer1",
                                  Tabs = new Tabs()
                                  {
                                      TextTabs = new List<Text>()
                                      {
                                          new Text()
                                          {
                                              DocumentId = docNumber,
                                              PageNumber = "1",
                                              XPosition = "100",
                                              YPosition = "100",
                                              Width = 120, 
                                              Value = "Some Tab Value " + docNumber
                                          }
                                      }
                                      
                                  }
                              }
                          }
                      }
                  }
              }
        }
	}
    
