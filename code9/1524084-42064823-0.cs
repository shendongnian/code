    AR303000Content custSchema = PX.Soap.Helper.GetSchema<AR303000Content>(context);
    //Save the initial field name of the CustomerID field string 
    initialCustomerIDFieldName = custSchema.CustomerSummary.CustomerID.FieldName;
    //Configure the command that searches for a customer record
    //by using the FilterEmail service command
    Field customerIDSelector = custSchema.CustomerSummary.CustomerID;
    customerIDSelector.FieldName += "!" +
    custSchema.CustomerSummary.ServiceCommands.FilterEmail.FieldName;
    var commands = new Command[]
    {
        new Value
        {
            Value = customerMainContactEmail,
            LinkedCommand = customerIDSelector
        },
    };
