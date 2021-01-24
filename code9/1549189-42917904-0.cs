    Screen context = new Screen();
    context.CookieContainer = new System.Net.CookieContainer();
    context.Url = "http://localhost/StackOverflow/Soap/AR301000.asmx";
    context.Login(username, password);
    try
    {
        Content invoiceSchema = PX.Soap.Helper.GetSchema<Content>(context);
        var commands = new Command[]
        {
            new Value
            {
                LinkedCommand = invoiceSchema.InvoiceSummary.Type,
                Value = "Credit Memo"
            },
            new Value
            {
                LinkedCommand = invoiceSchema.InvoiceSummary.ReferenceNbr,
                Value = "AR004776"
            },
            new Value
            {
                LinkedCommand = invoiceSchema.InvoiceSummary.Description,
                Value = "Test"
            },
            invoiceSchema.Actions.Save
        };
        context.Submit(commands);
    }
    finally
    {
        context.Logout();
    }
