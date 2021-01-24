    public partial class MainWindow : Window
    {
        public List<Patients> newPatientList = new List<Patients>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window1 addPx = new Window1(newPatientList);
            addPx.Show(); 
        }
    }
    public partial class Window1 : Window
    {
        List<Patients> _patients;
        public Window1(List<Patients> patients)
        {
            InitializeComponent();
            _patients = patients;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
        _patients.Add(new Patients(lstname.Text, frstname.Text, age.Text, 
                                            rm.Text, "", status.SelectedItem.ToString()));
        }
    }
