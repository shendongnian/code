    if (!IsPostBack)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select * from Employee where EmpUsername='" + Session["id"] + "'",con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                             txtCode.Text = (dr["EmployeeId"].ToString());
                        txtUsername.Text = (dr["EmpUsername"].ToString());
                        txtPass.Text = (dr["EmpPassword"].ToString());
                        txtEmail.Text = (dr["EmpEmail"].ToString());
                        txtFirstname.Text = (dr["EmpFirstName"].ToString());
                        txtLastname.Text = (dr["EmpLastName"].ToString());
                        txtGender.Text = (dr["EmpGender"].ToString());
                        txtContact.Text = (dr["EmpContact"].ToString());
                        txtAddress.Text = (dr["EmpAddress"].ToString());
                        txtDept.Text = (dr["EmpDept"].ToString());
                        }
                        dr.Close();
                        con.Close();
                    }
