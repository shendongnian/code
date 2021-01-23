    Screen context = new Screen();
    context.CookieContainer = new System.Net.CookieContainer();
    context.Url = "http://localhost/AP301000/Soap/AP301000.asmx";
    context.Login("admin", "123");
    Content billSchema = context.GetSchema();
    // 1st call to export all records from the Applications tab
    billSchema.DocumentSummary.Type.Commit = false;
    billSchema.DocumentSummary.Type.LinkedCommand = null;
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
        billSchema.Applications.DocTypeDisplayDocType,
        billSchema.Applications.ReferenceNbrDisplayRefNbr,
        billSchema.Applications.Balance
    };
    var applications = context.Submit(commands).ToList();
    // end of 1st call to export all records from the Applications tab
    // 2nd call to set AmountPaid in the Applications tab
    var cmds = new List<Command>();
    foreach (var application in applications)
    {
        cmds.Add(
            new Value
            {
                Value = applications.IndexOf(application).ToString(),
                LinkedCommand = billSchema.Applications.ServiceCommands.RowNumber
            });
        cmds.Add(
            new Value
            {
                Value = application.Applications.Balance.Value,
                LinkedCommand = billSchema.Applications.AmountPaid
            });
    }
    cmds.Add(billSchema.Actions.Save);
    context.Submit(cmds.ToArray());
    // end of 2nd call to set AmountPaid in the Applications tab
