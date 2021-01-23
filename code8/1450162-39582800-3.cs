    public partial class MainWindow : MetroWindow
    {
        MyViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
        }
        private void r1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            vm.Data.Remove(r.DataContext.ToString());
        }
    }
