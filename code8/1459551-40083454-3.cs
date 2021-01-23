    public partial class TemplateUserControl : UserControl
    {
        public TemplateUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty FirstButtonStyleProperty = 
            DependencyProperty.Register("FirstButtonStyle", typeof (Style), typeof (TemplateUserControl));
        
        public Style FirstButtonStyle
        {
            get { return (Style)GetValue(FirstButtonStyleProperty); }
            set { SetValue(FirstButtonStyleProperty, value); }
        }
        public static readonly DependencyProperty SecondButtonStyleProperty =
            DependencyProperty.Register("SecondButtonStyle", typeof (Style), typeof (TemplateUserControl));
        public Style SecondButtonStyle
        {
            get { return (Style)GetValue(SecondButtonStyleProperty); }
            set { SetValue(SecondButtonStyleProperty, value); }
        }
    }
