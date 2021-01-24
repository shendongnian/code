        public string LatitudeText
        {
            get { return (string)GetValue(LatitudeTextProperty); }
            set { SetValue(LatitudeTextProperty, value); }
        }
        public static readonly DependencyProperty LatitudeTextProperty =
            DependencyProperty.Register(nameof(LatitudeText), typeof(string), typeof(AddLocationControl), new PropertyMetadata(null, (d, e) => {}));
        public string LongitudeText
        {
            get { return (string)GetValue(LongitudeTextProperty); }
            set { SetValue(LongitudeTextProperty, value); }
        }
        public static readonly DependencyProperty LongitudeTextProperty =
            DependencyProperty.Register(nameof(LongitudeText), typeof(string), typeof(AddLocationControl), new PropertyMetadata(null, (d, e) => {}));
