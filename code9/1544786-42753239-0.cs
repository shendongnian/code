     public class MainWindow : Page
        {
            public Foo Foo { get; set; }
    
            public MainWindow()
            {
                DataContext = this;
            }
        }
    
    
        public class Foo : INotifyPropertyChanged
        {
            private double _fontSize;
    
            public double FontSize
            {
                get { return _fontSize; }
                set
                {
                    _fontSize = value;
                    OnPropertyChanged(nameof(FontSize));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
