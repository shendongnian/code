        Screen context = new Screen();
        context.CookieContainer = new System.Net.CookieContainer();
        context.Url = "http://localhost/StackOverflow/Soap/AR303000.asmx";
        context.Login(username, password);
        try
        {
            Content customerSchema = context.GetSchema();
            customerSchema.MailingSettingsMailings.EmailAccount.FieldName += "!Address";
            var commands = new Command[]
            {
                new Value
                {
                    Value = "ABCVENTURE",
                    LinkedCommand = customerSchema.CustomerSummary.CustomerID
                },
                customerSchema.MailingSettingsMailings.ServiceCommands.NewRow,
                new Value
                {
                    Value = "INVOICE",
                    LinkedCommand = customerSchema.MailingSettingsMailings.MailingID,
                },
                new Value
                {
                    Value = "HQ",
                    LinkedCommand = customerSchema.MailingSettingsMailings.Branch,
                },
                new Value
                {
                    Value = "admin@revisiontwo.com",
                    LinkedCommand = customerSchema.MailingSettingsMailings.EmailAccount,
                    Commit = true
                },
                customerSchema.MailingSettingsRecipients.ServiceCommands.NewRow,
                new Value
                {
                    Value = "Contact",
                    LinkedCommand = customerSchema.MailingSettingsRecipients.ContactType,
                },
                new Value
                {
                    Value = "Palmer, Steve",
                    LinkedCommand = customerSchema.MailingSettingsRecipients.ContactID,
                    Commit = true
                },
                customerSchema.Actions.Save
            };
            context.Submit(commands);
        }
        finally
        {
            context.Logout();
        }
