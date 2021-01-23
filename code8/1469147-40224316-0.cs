    using MimeKit;
    using MailKit;
    using MailKit.Net.Pop3;    
    
    public DataTable ReadEmailsFromId()
    {
        DataTable table = new DataTable();
        try
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect("pop.mail.yahoo.com", 995, true); //For SSL                
                client.Authenticate("Username", "Password");
    
                for (int i = client.Count - 1; i >= 0; i--)
                {
                    var msg = client.GetMessage (i);
    
                    table.Rows.Add(msg.Subject, msg.Date);
                    string msdId = msg.MessageId;
                    string message = msg.TextBody;
                }
            }
        }
    return table;
    }
