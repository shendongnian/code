    namespace Company
    {
        public partial class Register : Form
        {
            EmployeeDAO employeeDAO;
    
            public Register(EmployeeDAO employeeDAO)
            {
                InitializeComponent();
                this.employeeDAO = employeeDAO;
            }
    
            private void btnRegister_Click(object sender, EventArgs e)
            {
                Employee employee = new Employee();
                employee.idEmployee = Convert.ToInt16(this.txtId.Text);
                employee.nameEmployee = this.txtName.Text;
                employeeDAO.insert(employee);
    
            }
    
        }
    }
    namespace Company
    {
        class EmployeeDAO
        {
            List<Employee> Items {get; private set;}
            public EmployeeDAO()
            {
                Items = new List<Employee>();
            }
    
            public void insert(Employee employee)
            {
                Items.Add(employee);
            }
        }
    }
    namespace Company
    {
        public partial class Main : Form
        {
            EmployeeDAO employeeDAO;
            public Main()
            {
                InitializeComponent();
                lstEmployee.View = View.Details;
                lstEmployee.FullRowSelect = true;
                lstEmployee.Columns.Add("ID", 150);
                lstEmployee.Columns.Add("Nome", 150);
                employeeDAO = new EmployeeDAO();
                
            }
    
            private void InsertEmployeesInListBox()
            {
                lstEmployee.Items.Clear();
                foreach (var item in employeeDAO.Items)
                {
                    string[] row = { item.idEmployee.ToString(), item.nameEmployee };
                    var listViewItem = new ListViewItem(row);
                    lstEmployee.Items.Add(listViewItem);
                }
           
            }
    
            private void btnRegister_Click(object sender, EventArgs e)
            {
                Register register = new Register(employeeDAO);
                register.Show();
                this.Hide();
            }
        }
    }
