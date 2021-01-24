    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
    }
    public class ViewModel
    {
        public Employee Employee { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ViewModel()
        {
            Departments = new ObservableCollection<Department>()
            {
                new Department{ Id=1, Name="Department 1" },
                new Department{ Id=2, Name="Department 2" },
                new Department{ Id=2, Name="Department 3" },
            };
            Employee = new Employee()
            {
                FirstName = "Harry",
                LastName = "Park",
                Department = Departments.First(),
            };
        }
    <Grid>
        <ComboBox Height="30"
                ItemsSource="{Binding Departments}"
                SelectedValue="{Binding Employee.Department}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
    </Grid>
