    public partial class PopUp : Window
    {
        private readonly LayoutWindow _lw;
        public PopUp(LayoutWindow lw)
        {
            InitializeComponent();
            _lw = lw;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _lw.diagram.Bounds = new Rect(0, 0, 400, 400);
            Close();
        }
    }
