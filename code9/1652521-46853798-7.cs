        public TimeSpan MovieElapsedTime
        {
            get { return (TimeSpan)GetValue(MovieElapsedTimeProperty); }
            set { SetValue(MovieElapsedTimeProperty, value); }
        }
        public static readonly DependencyProperty MovieElapsedTimeProperty =
            DependencyProperty.Register(nameof(MovieElapsedTime), typeof(TimeSpan), typeof(MainWindow),
                new PropertyMetadata(null));
