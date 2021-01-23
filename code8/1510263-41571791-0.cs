        public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
            Load += new EventHandler(dataEmployees_Load); //Added this code
        }
        // Load all employees
        private void dataEmployees_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                (
                    "Select fname,ename FROM dbo.Users", con
                );
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataEmployees.DataSource = dt;
            }
        }
