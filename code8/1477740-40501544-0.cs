        public static DataTable dt = new DataTable();
        public void GetDepartment_temp()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connString);
                SqlCommand command =
                    new SqlCommand(
                        "select  Department.DepartmentID, Department.[Department Name], count( Department.DepartmentID) as empCount from Department join Employee on Department.DepartmentID = Employee.DepartmentID group by Department.DepartmentID, Department.[Department Name]",
                        connection);
                command.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dt.PrimaryKey = new DataColumn[] {dt.Columns["DepartmentID"]};
                ListBox1.ClearSelection();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ListBox1.Items.Add(new ListItem(row["Department Name"].ToString(),
                            row["DepartmentID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            DataRow dr = dt.Rows.Find(Convert.ToInt32(ListBox1.SelectedItem.Value));
            TextBox5.Text = dr["empCount"].ToString();
        }
