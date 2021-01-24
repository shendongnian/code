    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public ObservableCollection<string> Tasks { get; set; } = new ObservableCollection<string>() { "Starting item" };
        public bool IsTasksEmpty => Tasks.Count < 1;
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            Tasks.CollectionChanged += (sender, e) => RaiseProperty(nameof(IsTasksEmpty));
        }
        private void AddButton_Click(object sender, RoutedEventArgs e) => Tasks.Add("Next item");
        private void DelButton_Click(object sender, RoutedEventArgs e) => Tasks.RemoveAt(Tasks.Count - 1);
    }
