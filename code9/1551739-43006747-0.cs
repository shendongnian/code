            // Add a recipient to sign the documeent
            Signer signer = new Signer();
            signer.Email = "Janedoe@dsxtr.com";
            signer.Name = "Jane Doe";
            signer.RecipientId = "1";
            // Create a |SignHere| tab somewhere on the document for the recipient to sign
            signer.Tabs = new Tabs()
            {
                NumberTabs = new List<Number>()
                
            };
            var numberTab = new Number()
            {
                DocumentId = "1",
                PageNumber = "1",
                RecipientId = "1",
                XPosition = "100",
                YPosition = "100",
                Width = 80
            };
            signer.Tabs.NumberTabs.Add(numberTab);
