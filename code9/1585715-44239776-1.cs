    public partial class RxWindow : Window
    {
        public RxWindow()
        {
            InitializeComponent();
            this.WhenAnyValue(p => p.FilterText.Text)
                .Subscribe(_ => MessageBox.Show(""));
        }
    }
