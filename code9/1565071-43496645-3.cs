    public partial class MainWindow6 : Window, INotifyPropertyChanged {
        public MainWindow6() {
            DataContext = this;
            InitializeComponent();
            var colors = new Collection<ColorGradientHelper>();
            colors.Add(new ColorGradientHelper {
                BorderColor = Colors.Orange,
                Color1 = Colors.Purple,
                Color2 = Colors.White
            });
            colors.Add(new ColorGradientHelper {
                BorderColor = Colors.Orange,
                Color1 = Colors.Black,
                Color2 = Colors.Yellow
            });
            ColorCollection = colors;
        }
        private Collection<ColorGradientHelper> _colorCollection;
        public Collection<ColorGradientHelper> ColorCollection {
            get {
                return _colorCollection;
            }
            set {
                _colorCollection = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
