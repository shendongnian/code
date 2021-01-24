    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel model = (MainViewModel)DataContext;
            model.JobTimers.CollectionChanged += _OnJobTimersCollectionChanged;
        }
        private void _OnJobTimersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<JobTimer> jobTimers = (ObservableCollection<JobTimer>)sender;
            // Scroll to newly created timer
            JobTimer lastTimer = jobTimers.Last();
            listBox1.ScrollIntoView(lastTimer);
        }
    }
