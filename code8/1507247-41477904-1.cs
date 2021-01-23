    ImapClient client = new ImapClient("ExampleHost", port, ssl);
    client.DefaultMailbox = "[Gmail]/Sent Mail";
    try
    {
        client.Login("ExampleEmail", "ExamplePass", AuthMethod.Login);
        IEnumerable<uint> units = client.Search(SearchCondition.Seen());
        DataTable TempTaskTable = new DataTable();
        TempTaskTable.Columns.Add("FromEmail", typeof(string));
        TempTaskTable.Columns.Add("ToEmail", typeof(string));
        TempTaskTable.Columns.Add("Subject", typeof(string));
    	foreach (var uid in units)
        {
    		System.Net.Mail.MailMessage email = client.GetMessage(uid,true, "[Gmail]/Sent Mail");
            DataRow TempTaskRow2 = TempTaskTable.NewRow();
            TempTaskRow2["FromEmail"] = email.Sender;
            TempTaskRow2["ToEmail"] = email.From;
            TempTaskRow2["Subject"] = email.Subject;
        }
    }
    catch (Exception ex)
    {
    	string exceptionCheck = ex.Message;
    }
