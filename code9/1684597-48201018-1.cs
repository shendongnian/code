    public sealed partial class MainPage : Page
    {
        
        public ObservableCollection<Song> Songs { get; set; }
        private Song _currentSelectedItem;
        public Song currentSelectedItem
        {
            get { return _currentSelectedItem; }
            set
            {
                if (_currentSelectedItem != null)
                {
                    _currentSelectedItem.customcolor = new SolidColorBrush(Colors.Black);
                }
                _currentSelectedItem = value;
                _currentSelectedItem.customcolor = new SolidColorBrush(Colors.Red);
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            Songs = new ObservableCollection<Song>();
            Songs.Add(new Song() {Name="abc",Artist="Singer1" });
            Songs.Add(new Song {Name="def",Artist="Singer2" });
            this.DataContext = this;
        }
    }
