    class Program
        {
            static void Main(string[] args)
            {
                EmailExchange emailExchange = new EmailExchange();
                emailExchange.Domain = ConfigurationManager.AppSettings["Domain"];
                emailExchange.EmailID = ConfigurationManager.AppSettings["EmailID"];
                emailExchange.Password = ConfigurationManager.AppSettings["Password"];                
                emailExchange.Watch();
    
                Console.ReadLine();
            }
    
        }
    
    
    public class EmailExchange : IDisposable
        {
            public string Password { get; set; }
            public string EmailID { get; set; }
            public string Domain { get; set; }            
            public string ExchangeURL
            {
                get { return "https://outlook.office365.com/EWS/Exchange.asmx"; }
            }        
            private StreamingSubscriptionConnection connection = null;
            private ExchangeService service = null;
            public void Watch()
            {
                service = new ExchangeService();
                service.Credentials = new WebCredentials(EmailID, Password, Domain);            
                service.Url = new Uri(ExchangeURL);
                StreamingSubscription streamingsubscription = service.SubscribeToStreamingNotifications(new FolderId[] { WellKnownFolderName.Inbox }, EventType.NewMail);            
                connection = new StreamingSubscriptionConnection(service, 5);
                connection.AddSubscription(streamingsubscription);
                connection.OnNotificationEvent += OnNotificationEvent;
                connection.OnSubscriptionError += OnSubscriptionError;
                connection.OnDisconnect += OnDisconnect;
                connection.Open();
            }
    
            private void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
            {
                Console.WriteLine("Disconnected");
                if (!connection.IsOpen)
                    connection.Open();
            }
    
            private void OnSubscriptionError(object sender, SubscriptionErrorEventArgs args)
            {
    
            }
    
            private void OnNotificationEvent(object sender, NotificationEventArgs args)
            {
                foreach (var notification in args.Events)
                {
                    if (notification.EventType != EventType.NewMail) continue;
    
                    var itemEvent = (ItemEvent)notification;               
                    // add you code here
                }
            }
    
    
    
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
