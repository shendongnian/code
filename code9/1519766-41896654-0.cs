    public partial class Cross : UserControl, INotifyPropertyChanged
    {
        public Cross()
        {
            InitializeComponent();
        }
        public readonly static DependencyProperty CenterPointProperty = DependencyProperty.Register("CenterPoint",
            typeof(PointF), typeof(Cross),
            new PropertyMetadata(default(PointF), new PropertyChangedCallback(OnCenterPointUpdated))));
        private static void OnCenterPointUpdated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Cross cross = d as Cross;
            cross.NotifyPropertyChanged("X1");
            cross.NotifyPropertyChanged("X2");
            cross.NotifyPropertyChanged("Y1");
            cross.NotifyPropertyChanged("Y2");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        ...
    }
