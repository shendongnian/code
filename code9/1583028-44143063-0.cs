    private static bool RedirectionUrlValidationCallback(string redirectionUrl)
    {
        // The default for the validation callback is to reject the URL.
        bool result = false;
        Uri redirectionUri = new Uri(redirectionUrl);
        // Validate the contents of the redirection URL. In this simple validation
        // callback, the redirection URL is considered valid if it is using HTTPS
        // to encrypt the authentication credentials. 
        if (redirectionUri.Scheme == "https")
        {
            result = true;
        }
        return result;
    }
    static void Main(string[] args)
    {
        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
        service.Credentials = new WebCredentials("email@myemail.com", "myPassword");
        service.AutodiscoverUrl("email@myemail.com", RedirectionUrlValidationCallback);
                //creates an object that will represent the desired mailbox
        Mailbox mb = new Mailbox(@"email@myemail.com");
        //creates a folder object that will point to inbox folder
        FolderId fid = new FolderId(WellKnownFolderName.Inbox, mb);
        //this will bind the mailbox you're looking for using your service instance
        Folder inbox = Folder.Bind(service, fid);
        //load items from mailbox inbox folder
        if (inbox != null)
        {
            FindItemsResults<Item> items = inbox.FindItems(new ItemView(100));
            foreach (var item in items)
            {
                item.Load();
                Console.WriteLine("Subject: " + item.Subject);
            }
        }
    }   
