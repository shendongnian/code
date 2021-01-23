    class Class1 : DependencyObject {
        public string Text1 {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text1", typeof(string), typeof(Class1),
            new PropertyMetadata(true));
    }
    class Class2 : INotifyPropertyChanged {
        private string _text2;
        public string Text2 {
            get { return _text2; }
            set {
                if (value == _text2) return;
                _text2 = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
