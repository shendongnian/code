    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                //InitializeComponent();
                Size = new Size(600, 400);
                var employeeList =
                (
                    from e in XDocument.Load("test.xml").Root.Elements("employee")
                    select new Employee
                    {
                        EmployeeID = (int)e.Element("id"),
                        EmployeeName = (string)e.Element("name"),
                        EmployeePosition = (string)e.Element("position"),
                        EmployeeCountry = (string)e.Element("country"),
                        Projects =
                        (
                            from p in e.Elements("projects").Elements("project")
                            select new Project
                            {
                                ProjectCode = (string)p.Element("code"),
                                ProjectBudget = (int)p.Element("budget")
                            }).ToArray()
                    }).ToList();
                var employeesDataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
                var projectsDataGridView = new DataGridView { Parent = this, Dock = DockStyle.Bottom };
                var employeesBindingSource = new BindingSource();
                employeesBindingSource.DataSource = employeeList;
                var projectsBindingSource = new BindingSource();
                projectsBindingSource.DataSource = employeesBindingSource;
                projectsBindingSource.DataMember = nameof(Employee.Projects);
                employeesDataGridView.DataSource = employeesBindingSource;
                projectsDataGridView.DataSource = projectsBindingSource;
            }
        }
        public class Employee
        {
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string EmployeePosition { get; set; }
            public string EmployeeCountry { get; set; }
            public Project[] Projects { get; set; }
        }
        public class Project
        {
            public string ProjectCode { get; set; }
            public int ProjectBudget { get; set; }
        }
    }
