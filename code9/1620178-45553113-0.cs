    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var objectNeedingDispatcher = new ClassNeedingDispatcher(this.Dispatcher);
        }
    }
    public class ClassNeedingDispatcher
    {
        private readonly Dispatcher _injectedDispatcher;
    
        public ClassNeedingDispatcher(Dispatcher injectedDispatcher)
        {
            _injectedDispatcher = injectedDispatcher;
        }
    }
