    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*string connectionString = ConfigurationManager
                    .ConnectionStrings["SqlSqlConnection"].ConnectionString;
    
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Employees";
                        cmd.Connection = con;
                        con.Open();
                        GridView1.DataSource = cmd.ExecuteReader();
                        GridView1.DataBind();
                    }
                }*/
    
                // Since I do not have database, I've to manually populate the data here.
                EmployeeGridView.DataSource = new List<Employee>
                {
                    new Employee {Id = 1, FirstName = "John", LastName = "Doe"},
                    new Employee {Id = 2, FirstName = "Janet", LastName = "Doe"},
                    new Employee {Id = 3, FirstName = "Eric", LastName = "Newton"}
                };
                EmployeeGridView.DataBind();
            }
        }
    
        protected void PrintButton_Command(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument;
        }
    
        protected void CloseButton_Command(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument;
        }
    }
    
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
