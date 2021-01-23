     using OpenPop.Pop3;    
        public DataTable ReadEmailsFromId()
        {
            DataTable table = new DataTable();
            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect("pop.gmail.com", 995, true); //For SSL                
                    client.Authenticate("recent:Username", "Password", AuthenticationMethod.UsernameAndPassword);
                    int messageCount = client.GetMessageCount();
                    for (int i = messageCount; i > 0; i--)
                    {
                        table.Rows.Add(client.GetMessage(i).Headers.Subject, client.GetMessage(i).Headers.DateSent);
                        string msdId = client.GetMessage(i).Headers.MessageId;
                        OpenPop.Mime.Message msg = client.GetMessage(i);
                        OpenPop.Mime.MessagePart plainTextPart = msg.FindFirstPlainTextVersion();
                        string message = plainTextPart.GetBodyAsText();                           
                    }
                }
            }
        return table;
        }
