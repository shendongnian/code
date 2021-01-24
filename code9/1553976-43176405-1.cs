        Screen context = new Screen();
        context.CookieContainer = new System.Net.CookieContainer();
        context.Url = "http://localhost/StackOverflow/Soap/AR303000.asmx";
        context.Login(username, password);
        try
        {
            Content customerSchema = context.GetSchema();
            var commands = new Command[]
            {
                new Value
                {
                    Value = "ABCSTUDIOS",
                    LinkedCommand = customerSchema.CustomerSummary.CustomerID
                },
                new Key
                {
                    Value = "='INVOICE'",
                    FieldName = customerSchema.MailingSettingsMailings.MailingID.FieldName,
                    ObjectName = customerSchema.MailingSettingsMailings.MailingID.ObjectName
                },
                customerSchema.MailingSettingsMailings.MailingID,
                customerSchema.MailingSettingsRecipients.ServiceCommands.NewRow,
                new Value
                {
                    Value = "Contact",
                    LinkedCommand = customerSchema.MailingSettingsRecipients.ContactType,
                },
                new Value
                {
                    Value = "Harper, Travis",
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
