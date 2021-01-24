        public partial class TestUserControl : UserControl
        {
            public TestUserControl()
            {
                InitializeComponent();
            }
        
            public static readonly DependencyProperty TestDependencyProperty =
                DependencyProperty.Register("TestProperty",
                    typeof(string),
                    typeof(TestUserControl));
        
            [Bindable(true)]
            public string TestProperty
            {
                get
                {
                    return (string)this.GetValue(TestDependencyProperty);
                }
                set
                {
                    this.SetValue(TestDependencyProperty, value);
                }
            }
    }
