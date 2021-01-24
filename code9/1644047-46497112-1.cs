     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDataSource();
        }
        public async void SetDataSource()
        {
            dgProducts.DataSource = await Task.Run(() =>
            {
                //My DB call goes here... and populates productCollection used in step 2 below
                return productCollection;
            });
        }
    }
