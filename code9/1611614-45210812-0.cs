    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandManager.AddPreviewExecutedHandler(RTBPopup, new ExecutedRoutedEventHandler(OnExecuted));
        }
        private void OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Command == EditingCommands.ToggleBold)
            {
                MessageBox.Show("fired!");
            }
        }
    }
