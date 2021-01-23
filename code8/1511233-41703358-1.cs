    Screen context = new Screen();
    context.CookieContainer = new System.Net.CookieContainer();
    context.Url = "http://localhost/ItemCertificationStatus/Soap/AP301000.asmx";
    context.Login("admin", "123");
    Content billSchema = context.GetSchema();
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
        new Key
        {
            ObjectName = billSchema.Applications.DocTypeDisplayDocType.ObjectName,
            FieldName = billSchema.Applications.DocTypeDisplayDocType.FieldName,
            Value = "Prepayment"
        },
        new Key
        {
            ObjectName = billSchema.Applications.ReferenceNbrDisplayRefNbr.ObjectName,
            FieldName = billSchema.Applications.ReferenceNbrDisplayRefNbr.FieldName,
            Value = "000591"
        },
        new Value
        {
            Value = "25.0",
            LinkedCommand = billSchema.Applications.AmountPaid
        },
        billSchema.Actions.Save
    };
    context.Submit(commands);
