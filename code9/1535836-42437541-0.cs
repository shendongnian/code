    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SizeChanged += (s, e) => 
            {
                GridView gv = listView.View as GridView;
                gv.Columns[0].Width = ...;
            };
        }
    }
