    namespace WpfApplication1
    {
    /// <summary>
    /// Interaction logic for childWindow.xaml
    /// </summary>
    public partial class childWindow : Window
    {
        public MainWindow mainWindow;
        public int Param1 { get; set; }
        public string Param2 { get; set; }
        public childWindow(MainWindow _mainWindow)
        {
            InitializeComponent();
            this.mainWindow = _mainWindow;
            this.Loaded += ChildWindow_Loaded;
        }
        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //You can get or set your main window properties. 
            this.mainWindow.MainWindowProp1 = 5;
            this.mainWindow.MainWindowProp2 = "test";
            //You can call methods ant events etc.. of your main window too (depending on acces modifiers).
          this.mainWindow.TestMethod();
        }
    }
}
