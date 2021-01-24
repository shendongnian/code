    public class ServerViewModel : BaseViewModel
    {
        public RelayCommand BroadcastMessageCommand { get; set; }
        private string _broadcastmessage;
        public string broadcastmessage
        {
            get { return _broadcastmessage; }
            set { _broadcastmessage = value; RaisePropertyChanged("broadcastmessage"); }
        }
        Server server;
        
        public ServerViewModel()
        {
            server = new Server();
            server.run();
            BroadcastMessageCommand = new RelayCommand(BroadcastMessage, CanBroadcast);
        }
        
        private bool CanBroadcast(object param)
        {
            if (string.IsNullOrWhiteSpace(broadcastmessage))
                return false;
            if (!server.running)
                return false;
            return true;
        }
        public void BroadcastMessage(object param)
        {
            server.BroadcastMessage(broadcastmessage);
            broadcastmessage = "";
            RaisePropertyChanged("broadcastmessage");
        }
    }
