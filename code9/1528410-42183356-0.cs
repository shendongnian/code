        public int Länge
        {
            get { return (int)GetValue(LängeProperty); }
            set { SetValue(LängeProperty, value); }
        }
        public static readonly DependencyProperty LängeProperty =
          DependencyProperty.Register(
          "Länge ", typeof(int), typeof(MainWindow), new PropertyMetadata(50));
