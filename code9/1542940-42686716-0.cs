    public System.Threading.Timer UpdateTimer;
    public MainFunction()
    {
        this.InitializeComponent();
        UpdateTimer = new System.Threading.Timer(UpdateList_Tick);
        UpdateTimer.Change(0, 15000);
        //...
    }
    private async void UpdateList_Tick(object state)
    {   
        using (var client = new ImapClient())
        {
            using (var cancel = new CancellationTokenSource())
            {
                await client.ConnectAsync("imap.gmail.com", 993, true, cancel.Token);
                client.AuthenticationMechanisms.Remove("XOAUTH");
                await client.AuthenticateAsync("email.com", "mail12345", cancel.Token);
                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly, cancel.Token);
                // let's try searching for some messages...
                DateTime date = DateTime.Now;
                DateTime mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
                var query = SearchQuery.DeliveredAfter(mondayOfLastWeek)
                    .And(SearchQuery.SubjectContains("search"))
                    .And(SearchQuery.All);
                List<string> newList = new List<string>();
                foreach (var uid in inbox.Search(query, cancel.Token))
                {
                    var message = inbox.GetMessage(uid, cancel.Token);
                    string trimmedMSGEmtyLines = Regex.Replace(message.TextBody, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                    newList.Add(message.Date.LocalDateTime + Environment.NewLine + trimmedMSGEmtyLines);
                }
                await client.DisconnectAsync(true, cancel.Token);
                if (!GlobalVars.MainList.SequenceEqual(newList))
                {
                    GlobalVars.MainList = newList;
                }
            }
        }
    }
