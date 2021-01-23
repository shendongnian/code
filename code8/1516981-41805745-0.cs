    public partial class HostWindow : Window
    {
        public HostWindow()
        {
            InitializeComponent();
            PreviewMouseLeftButtonDown += (s, e) => e.Handled = true;
        }
    }
