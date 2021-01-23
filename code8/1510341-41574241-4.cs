    public partial class CompanyForm : Form
    {
        private DataTable dataEmployeesSource = new DataTable();
        public CompanyForm()
        {
            InitializeComponent();
            
            initDataEmployees();
            initCompanyList();
            
            companyList.SelectedIndexChanged += listbox1_SelectedIndexChanged;
        }
        
        private void initDataEmployees()
        {
            const string sql = "Select fname, ename, c.companyName AS companyName FROM dbo.Users u inner join dbo.Company c on c.companyName = u.company;";
            dataEmployeesSource = selectIntoDataTable(sql);
            dataEmployees.DataSource = dataEmployeesSource;
        }
        
        private void initCompanyList()
        {
            const string sql = "Select companyName from dbo.Company";
            try
            {
                DataTable dt = selectIntoDataTable(sql);
                companyList.DataSource = dt;
                companyList.ValueMember = "companyName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no companies to display");
            }
        }
        
        private DataTable selectIntoDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                }
            }
                return dt;
            }
        
        private void listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)companyList.SelectedItem;
            string selectedText = (string)selectedRow.Row["companyName"];
            DataView dv = dataEmployeesSource.DefaultView;
            
            string columnName = dataEmployeesSource.Columns[2].ColumnName;
            string filter = string.Format("{0} = '{1}'", columnName, selectedText);
            dv.RowFilter = filter;
            dataEmployees.DataSource = dv;
        }
    }
