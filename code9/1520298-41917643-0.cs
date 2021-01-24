    public string Name2
        {
            get { return (string)GetValue(Name2Property); }
            set { SetValue(Name2Property, value); }
        }
        public static readonly DependencyProperty Name2Property =
            DependencyProperty.Register(nameof(Name2), typeof(string), typeof(MainWindow));
