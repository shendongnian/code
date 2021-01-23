    using System.Collections.ObjectModel;
    using System.Timers;
    using System.Windows;
    using System.Windows.Data;
    namespace TestEer
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private readonly object _sync = new object( );
        public MainWindow( )
        {
            InitializeComponent( );
            BindingOperations.EnableCollectionSynchronization( ErrorMessages, _sync );
            _timer = new Timer
            {
                AutoReset = true,
                Interval = 1000
            };
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _timer.Start( );
        }
        private void _timer_Elapsed( object sender, ElapsedEventArgs e )
        {
            ErrorMessages.Add( $"Error @ {e.SignalTime}" );
        }
        public ObservableCollection<string> ErrorMessages { get; } = new ObservableCollection<string>( );
    }
    }
    
