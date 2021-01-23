        private void loginButton_Click(object sender, EventArgs e)
        {
            //If use set quote into your textbox
            string name = nameTextBox.Text.Replace("'", "''");
            string pass = passwordTextBox.Text.Replace("'", "''");
            String query = string.Format("select * from Employees where Name = '{0}' and Password = '{1}'", name, pass);
            string employeeID = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=INCEPSYS-SE\TEST;Initial Catalog=Employee;Integrated Security=True"))
            {
                connection.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        employeeID = dt.Rows[0]["EmployeeID"].ToString();
                        this.Hide();
                        Entry ss = new Entry(employeeID);
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Check your Username & password");
                    }
                    dt.Dispose();
                }
            }
        }
