    public partial class MainWindow : Window
    {
        private Transfer _transfer = new Transfer();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource ();
        public MainWindow()
        {
            InitializeComponent(); 
        }
           
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<int> Data = new ObservableCollection<int>();
            try
            {
                await Task.Run(() => _transfer.GetData(Data, _cancellationTokenSource.Token);)
                listView1.ItemsSource = Data;
            }
            catch(OperationCanceledException ex)
            {
                MessageBox.Show("Canceled");
            }
        }
    
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
