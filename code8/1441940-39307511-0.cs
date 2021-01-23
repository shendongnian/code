    public static readonly DependencyProperty ScreenNameProperty =
            DependencyProperty.Register("ScreenName", typeof(String),
            typeof(ContentControl), new FrameworkPropertyMetadata("screen_1", new PropertyChangedCallback(ScreenNameChanged)));
        public String ScreenName
        {
            get { return (String)GetValue(ScreenNameProperty); }
            set { SetValue(ScreenNameProperty, value); }
        }
        private static void ScreenNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            ContentControl originator = dependencyObject as ContentControl;
            if (originator != null)
            {
                // navigate here
            }
        }
