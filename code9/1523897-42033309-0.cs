    public sealed partial class MyControl : UserControl
    {
        public MyControl()
        {
            this.InitializeComponent();
        }
        public static readonly DependencyProperty KindProperty = DependencyProperty.Register(
        "Kind", typeof(string), typeof(MyControl),
        new PropertyMetadata(null, new PropertyChangedCallback(OnKindChanged)));
        public string Kind
        {
            get { return (string)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }
        private static void OnKindChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Executed method when the KindProperty is changed
        }
    }
