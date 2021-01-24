    context.CookieContainer = new System.Net.CookieContainer();
    context.Timeout = System.Threading.Timeout.Infinite;
    context.Url = "http://localhost/Demo610u05/(W(346))/Soap/AP302000.asmx";
    LoginResult result = context.Login("admin@Company", "admin");
    AP302000Content checkSchema = context.AP302000GetSchema();
    var detailTypeNoCommit = checkSchema.DocumentsToApply.DocumentType;
	detailTypeNoCommit.Commit = false;
	var detailRefNbrNoCommit = checkSchema.DocumentsToApply.ReferenceNbrAdjdRefNbr;
	detailRefNbrNoCommit.Commit = false;
	var detailamountPaidNoCommit = checkSchema.DocumentsToApply.AmountPaid;
	detailamountPaidNoCommit.Commit = false;
    List<Command> cmds = new List<Command>();
    cmds.Add(new Value { LinkedCommand = checkSchema.PaymentSummary.Type, Value = "Prepayment" });
    cmds.Add(checkSchema.Actions.Insert);
    cmds.Add(new Value { LinkedCommand = checkSchema.PaymentSummary.ReferenceNbr, Value = "1600001331"});
    cmds.Add(checkSchema.DocumentsToApply.ServiceCommands.NewRow);
    cmds.Add(new Value { LinkedCommand = detailTypeNoCommit, Value = "Bill" });
    cmds.Add(new Value { LinkedCommand = detailRefNbrNoCommit, Value = "1600003050"});
    cmds.Add(new Value { LinkedCommand = detailamountPaidNoCommit, Value = "80000" });
    try
    {
       cmds.Add(checkSchema.Actions.Save);
       var result = context.AP302000Submit(cmds.ToArray());
    }
    catch (Exception ex)
    {
           MessageBox.Show(ex.Message);
    }
    finally
    {
       context.Logout();
    }
