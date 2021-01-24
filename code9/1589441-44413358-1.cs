    namespace POSystem
    {
      public partial class MainWindow : Window, INotifyPropertyChanged
      {
        private DataContext _data = new DataContext();
        internal DataContext Data { get => _data ?? new DataContext(); set => _data = value; }
    
        public MainWindow()
        {
          InitializeComponent();
          DataContext = POProperties.Instance;
        }    
    
        public void ClearFocus_OnClick(object sender, MouseButtonEventArgs e) { Keyboard.ClearFocus(); }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string Name = "")
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name)); }
      }
    }
