    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = newPerson;
        }
        Person newPerson = new Person();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            newPerson.Name = "";
        }
    }
