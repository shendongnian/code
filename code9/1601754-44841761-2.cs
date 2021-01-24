    namespace WpfApplication1
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Defining public or internal parameters
        public int MainWindowProp1 { get; set; }
        public string MainWindowProp2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //When you call your child window, pass this (mainwindow) as parameter.
            childWindow cw = new WpfApplication1.childWindow(this);
            cw.Param2 = "test";
            cw.Param1 = 12;
            cw.Closed += Cw_Closed;
            cw.ShowDialog();
        }
        private void Cw_Closed(object sender, EventArgs e)
        {
            //On closed event, you can cast the sender as your child window.
            var child = (sender as childWindow);
            var param1 = child.Param1;
            var param3 = child.Param2;
        }
        public void TestMethod()
        {
            //do anything you want
        }
    }
    }
