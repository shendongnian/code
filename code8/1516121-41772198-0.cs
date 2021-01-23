    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            DataContext = vm;
            AddHandler(KeyDownEvent, new KeyEventHandler((ss, ee) => 
            {
                vm.SomeCommand.Execute(null);
            }), true);
        }
    }
