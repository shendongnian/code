    public class SnakePattern
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SnakePattern> Patterns { get; }
            = new ObservableCollection<SnakePattern>();
        private SnakePattern selectedPattern;
        public SnakePattern SelectedPattern
        {
            get { return selectedPattern; }
            set
            {
                selectedPattern = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedPattern)));
            }
        }
    }
