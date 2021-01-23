      protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string query = "SELECT TOP 10 ContactName, City, Country FROM Customers;";
            query += "SELECT TOP 10 (FirstName + ' ' + LastName) EmployeeName, City, Country FROM Employees";
     
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            gvCustomers.DataSource = ds.Tables[0];
                            gvCustomers.DataBind();
                            gvEmployees.DataSource = ds.Tables[1];
                            gvEmployees.DataBind();
                        }
                    }
                }
            }
        }
    }
