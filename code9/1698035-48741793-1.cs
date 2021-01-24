    Code in usercontrol.cs(Add dependencyproperty)
        public UserControl1()
        {
            InitializeComponent();
        }
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public string CustomText
        {
            get { return (string)GetValue(textProperty); }
            set { SetValue(textProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(ImageSource), typeof(UserControl1));
        public static readonly DependencyProperty textProperty =
        DependencyProperty.Register("CustomText", typeof(string), typeof(UserControl1));
    }
