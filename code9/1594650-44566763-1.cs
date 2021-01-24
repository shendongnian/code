        private readonly INotificationHubClient _hub;
        public HomeController(NotificationHubConnectionSettings hub)
        {
            _hub = hub.Hub;
        }
