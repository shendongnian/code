    [ImplementPropertyChanged]
    public partial class Window1 : Window
    {
        MyViewModel VM;
        public Window1()
        {
            InitializeComponent();
            this.VM = new MyViewModel();
            this.DataContext = this.VM;
        }
    }
    [ImplementPropertyChanged]
    public class MyViewModel
    {
        public ObservableCollection<LogMessage> LogMessages { get; set; }
        public ObservableCollection<ServerTab> AllServers { get; set; }
        public ServerTab SelectedServer { get; set; }
        public MyViewModel()
        {
            this.AllServers = new ObservableCollection<ServerTab>();
            this.AllServers.Add(new ServerTab { Name = "+" });
            this.LogMessages = new ObservableCollection<LogMessage>();
        }
        private ICommand _AddNew;
        public ICommand AddNew { get { return _AddNew ?? (_AddNew = new DelegateCommand(a => AddNewCommand(a))); }}
        private void AddNewCommand(object item)
        {
            var senderItem = (ServerTab)item;
            if (senderItem.Name == "+")
            {
                var newItem = new ServerTab { Name = "Name " + (this.AllServers.Count) };
                this.AllServers.Remove(senderItem);
                this.AllServers.Add(newItem);
                this.AllServers.Add(senderItem);
                this.LogMessages.Add(new LogMessage { Time = DateTime.Now, Message = newItem.Name + " added" });
            }
        }
        private ICommand _Connect;
        public ICommand Connect{ get { return _Connect ?? (_Connect = new DelegateCommand(a => ConnectCommand(a))); }}
        private void ConnectCommand(object item)
        {
            this.LogMessages.Add(new LogMessage { Time = DateTime.Now, Message = this.SelectedServer.Name+" connected" });
        }
        private ICommand _Disconnect;
        public ICommand Disconnect{ get { return _Disconnect ?? (_Disconnect = new DelegateCommand(a => DisconnectCommand(a))); }}
        private void DisconnectCommand(object item)
        {
            this.LogMessages.Add(new LogMessage { Time = DateTime.Now, Message = this.SelectedServer.Name +" disconnected" });
        }
    }
    [ImplementPropertyChanged]
    public class ServerTab
    {
        public string Name { get; set; }
        public string SomeServerPropertyToDisplay { get; set; }
        public ServerTab()
        {
            SomeServerPropertyToDisplay = DateTime.Now.Ticks.ToString();
        }
    }
    [ImplementPropertyChanged]
    public class LogMessage
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
