    public ImageSource ImageSource {
            get {
                return GetValue(ImageSourceProperty) as ImageSource;
            }
            set {
                SetValue(ImageSourceProperty, value);
            }
        }
        public ObservableCollection<ImageSource> States { get; } = new ObservableCollection<ImageSource>();
        public int CurrentState { get; set; }
        public static readonly DependencyProperty ImageSourceProperty  = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(PointButton));
        public PointButton( ) {
            CurrentState = 0;
            InitializeComponent( );
            Loaded += PointButton_Loaded;
        }
        private void PointButton_Loaded(object sender, RoutedEventArgs e) {
            PreviewMouseUp += PointButton_MouseUp;
            UpdateLayout( );
            if(States == null)
                Console.WriteLine("States is null");
            else
                ImageSource = States[CurrentState];
        }
        private void PointButton_MouseUp(object sender, MouseButtonEventArgs e) {
            if(CurrentState == States.Count - 1)
                CurrentState = 0;
            else
                CurrentState += 1;
            ImageSource = States[CurrentState];
        }
    }
