    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelLine();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLine vm = (ViewModelLine)DataContext;
            // use other information and decide how you want to add the line
            Random ran = new Random();
            vm.Models.Add(new ModelLine() { X1=ran.Next(1,600), X2= ran.Next(1, 600), Y1= ran.Next(1, 600), Y2= ran.Next(1, 600) });
        }
    }
