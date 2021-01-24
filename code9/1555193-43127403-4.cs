    public partial class TextBoxUsrCtrl : UserControl
    {
        public TextBoxUsrCtrl()
        {
            InitializeComponent();
        }
        #region Text Property
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(String), typeof(TextBoxUsrCtrl),
                new FrameworkPropertyMetadata(null) {
                    //  It's read-write, so make it bind both ways by default
                    BindsTwoWayByDefault = true
                });
        #endregion Text Property
        #region DisplayText Property
        public String DisplayText
        {
            get { return (String)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register(nameof(DisplayText), typeof(String), typeof(TextBoxUsrCtrl),
                new PropertyMetadata(null));
        #endregion DisplayText Property
    }
