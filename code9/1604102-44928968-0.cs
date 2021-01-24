    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Viewbox vb = this.Template.FindName("viewBox", this) as Viewbox;
            if (vb != null)
                vb.Visibility = Visibility.Collapsed;
        }
    }
