    Screen context = new Screen();
    context.CookieContainer = new System.Net.CookieContainer();
    context.Url = "http://localhost/AP301000/Soap/AP301000.asmx";
    context.Login("admin", "123");
    Content billSchema = context.GetSchema();
    billSchema.DocumentSummary.Type.Commit = false;
    billSchema.DocumentSummary.Type.LinkedCommand = null;
    billSchema.Applications.ReferenceNbrDisplayRefNbr.LinkedCommand = null;
    var commands = new Command[]
    {
        new Value
        {
            Value = "Bill",
            LinkedCommand = billSchema.DocumentSummary.Type
        },
        new Value
        {
            Value = "000927",
            LinkedCommand = billSchema.DocumentSummary.ReferenceNbr
        },
        new Value
        {
            Value = "0",
            LinkedCommand = billSchema.Applications.ServiceCommands.RowNumber
        },
        new Value
        {
            Value = "10.0",
            LinkedCommand = billSchema.Applications.AmountPaid,
        },
        new Value
        {
            Value = "1",
            LinkedCommand = billSchema.Applications.ServiceCommands.RowNumber
        },
        new Value
        {
            Value = "15.0",
            LinkedCommand = billSchema.Applications.AmountPaid,
        },
        billSchema.Actions.Save
    };
    context.Submit(commands);
