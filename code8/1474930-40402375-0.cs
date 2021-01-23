    namespace MyAppManager
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : MetroWindow
        {
            #region Properties
            private static Logger logger = LogManager.GetCurrentClassLogger();
            private bool _shutdown;
            private readonly MainWindowViewModel _viewModel;
            internal static MainWindow Main;
            IHubProxy _hub;
            HubConnection connection;
    
            Timer hubTimer;
            #endregion
    
            #region Delegates
            public class ValidATMConnectedEventArgs : EventArgs
            {
                public ATMItem ATM { set; get; }
    
                public ValidATMConnectedEventArgs(ATMItem atm)
                {
                    ATM = atm;
                }
            }
            public delegate void ValidATMConnectedEventHandler(object sender, ValidATMConnectedEventArgs e); 
        
            #endregion
    
            #region Events
    
            public event ValidATMConnectedEventHandler ValidATMConnectedEvent;
            public void OnValidATMConnected(ValidATMConnectedEventArgs e)
            {
                ValidATMConnectedEvent?.Invoke(this, e);
            }
     
            #endregion
    
            #region Ctor
            public MainWindow()
            {
                InitializeComponent();
    
                hubTimer = new Timer();
                hubTimer.Interval = TimeSpan.FromMilliseconds(5000).TotalMilliseconds;
                hubTimer.Elapsed += HubTimer_Elapsed;
    
                _viewModel = new MainWindowViewModel(DialogCoordinator.Instance);
                DataContext = _viewModel;
    
                Loaded += MainWindow_Loaded;
            }
    
            private void HubTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (connection.State == ConnectionState.Disconnected)
                {
                    hubTimer.Enabled = false;
                    StartEventSniffer();
                    hubTimer.Enabled = true;
                }
            }
            #endregion
    
            #region Internal events
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                Main = this;
    
                #region Create HubConnection
                connection = new HubConnection(Properties.Settings.Default.HostNotificationURL);
    
                connection.StateChanged += Connection_StateChanged;
                connection.Error += Connection_Error;
                _hub = connection.CreateHubProxy("NotificationManager");
     
                #endregion
    
                StartEventSniffer();
    
                hubTimer.Start();
            }
    
            private void Connection_Error(Exception ex)
            {
                logger.Error(ex);
    
                if (connection.State == ConnectionState.Disconnected)
                {
                    StartEventSniffer();
                }
            }
    
            public void StartEventSniffer()
            {
                try
                { 
                    connection.Start().Wait();
     
                    #region ATM/Host Connection Events
                    _hub.On(HostNotificationManagerMethods.ValidATMConnected.ToString(), x =>
                    {
                        try
                        {
                          
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);
                        }
                    });
    
                    _hub.Invoke(HostNotificationManagerMethods.ValidATMConnected.ToString(), null).Wait();
     
    
                    
    
                    #endregion               
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
    
            private void Connection_StateChanged(StateChange obj)
            {
                if (obj.NewState == ConnectionState.Disconnected)
                {
                    StartEventSniffer();
                }
            }
            #endregion    
            
        }
    }
