    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UserControl1), new PropertyMetadata(null));
        public string ButtonText
        {
            get { return (string) GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(UserControl1), new PropertyMetadata(null));
    }
