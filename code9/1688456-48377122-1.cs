    public sealed partial class PageUserControl : UserControl
    {
        public PageUserControl()
        {
            this.InitializeComponent();
        }
    
        public static readonly DependencyProperty MainProperty = DependencyProperty.Register("Main", typeof(object), typeof(PageUserControl), new PropertyMetadata(null));
    
        public object Main
        {
            get { return GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }
    }
