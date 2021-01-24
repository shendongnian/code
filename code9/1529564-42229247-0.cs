    public partial class AddEmployeeWindow : Window
    {
        private readonly EmployeePages _empPage;
        public AddEmployeeWindow(EmployeePages empPage)
        {
            _empPage = empPage;
            InitializeComponent();
        }
        //...
        public void Refresh()
        {
            dbManagement.EmployeesDbConnection(newEmployee, "CollectionViewSource", _empPage);
        }
    }
