        public void CreateEnvelopeSeparateEmailNotificationForRecipients()
        {
            string accountID = Init();
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\praveen.reddy\Box Sync\AnchorTagsTest.pdf");
            var envDef = new EnvelopeDefinition()
            {
                Status = "sent",
                Recipients = new Recipients()
                {
                    Signers = new List<Signer>() 
                    {
                        new Signer()
                        {
                            Email = "janedoe@acme.com",
                            Name = "jane doe",
                            RecipientId = "1",
                            RoutingOrder = "1",
                            EmailNotification = new RecipientEmailNotification()
                            {
                                EmailSubject = "Please sign the  document(s) (jane doe)",
                                EmailBody = "This is email body for Jane Doe"
                            },
                            Tabs = new Tabs() { SignHereTabs =  new List<SignHere>(){ new SignHere() { DocumentId = "1", XPosition = "100",YPosition = "300", PageNumber = "1" } } }
                        },
                        new Signer()
                        {
                            Email = "johnsmith@acme.com",
                            Name = "JohnSmith",
                            RecipientId = "2",
                            RoutingOrder = "1",
                            EmailNotification = new RecipientEmailNotification()
                            {
                                EmailSubject = "Please sign the  document(s) (John Smith)",
                                EmailBody = "This is email body for John Smith"
                            },
                            Tabs = new Tabs() { SignHereTabs =  new List<SignHere>(){ new SignHere() { DocumentId = "1", XPosition = "200",YPosition = "300", PageNumber = "1" } } }
                        }
                    }
                },
                Documents = new List<Document>()
                {
                    new Document()
                    {
                        DocumentBase64 = System.Convert.ToBase64String(fileBytes),
                        Name = "Contract",
                        DocumentId = "1"
                    }
                }				
            };
            EnvelopesApi envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountID, envDef);
        }
