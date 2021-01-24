    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }
        #region Status Property
        public int Status
        {
            get { return (int)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(nameof(Status), typeof(int), typeof(StatusControl),
                new PropertyMetadata(0));
        #endregion Status Property
        private void StatusSelect_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Status = Grid.GetColumn(sender as UIElement);
        }
    }
