    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();
            datagrid1.DataContext = this;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Employees.Add(new Employee
            {
                Name = "Name",
                Age = (new Random()).Next(0, 100)
            });
        }
    }
