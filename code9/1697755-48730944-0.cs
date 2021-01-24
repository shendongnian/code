    protected void Page_Load(object sender, EventArgs e)
            {
    
                using (SqlConnection con = new SqlConnection("Data Source=USER-PC;Initial Catalog=1GCAttendanceManagementSystem;Integrated Security=True"))
                {
    
                    con.Open();
    
                    SqlDataReader myReader = null;
    
                    var salaryParam = new SqlParameter("EmpUsername", SqlDbType.VarChar);
                    salaryParam.Value = Session["id"];
    
                    SqlCommand myCommand = new SqlCommand("select TOP 1 * from Employee where EmpUsername='@EmpUsername'", con);
                    myCommand.Parameters.Add(salaryParam);
    
                    myReader = myCommand.ExecuteReader();
    
                    if (myReader.Read())
                    {
                        txtCode.Text = (myReader["EmployeeId"].ToString());
                        txtUsername.Text = (myReader["EmpUsername"].ToString());
                        txtPass.Text = (myReader["EmpPassword"].ToString());
                        txtEmail.Text = (myReader["EmpEmail"].ToString());
                        txtFirstname.Text = (myReader["EmpFirstName"].ToString());
                        txtLastname.Text = (myReader["EmpLastName"].ToString());
                        txtGender.Text = (myReader["EmpGender"].ToString());
                        txtContact.Text = (myReader["EmpContact"].ToString());
                        txtAddress.Text = (myReader["EmpAddress"].ToString());
                        txtDept.Text = (myReader["EmpDept"].ToString());
                    }
    
                }
            }
