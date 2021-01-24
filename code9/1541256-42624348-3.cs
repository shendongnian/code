        public MyUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty LabelWidthProperty =
             DependencyProperty.Register("LabelWidth", typeof(System.Windows.GridLength),
             typeof(MyUserControl));
        public System.Windows.GridLength LabelWidth
        {
            get { return (System.Windows.GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }
        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(System.Windows.GridLength),
                typeof(MyUserControl));
        public System.Windows.GridLength ContentWidth
        {
            get { return (System.Windows.GridLength)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }
    }
