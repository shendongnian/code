    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine("sdfgsdgdsgdf");
        }
        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
