    private void textBox5_TextChanged(object sender, EventArgs e)
      {
    	if(con == null)
    	{
    		con=new SqlConnection(@"Data Source = LAPTOP-VHSGV41H\SQLEXPRESS; Initial Catalog = EmpDB; Integrated Security = True");
    	}
    	if(con.State == ConnectionState.Closed)
    	{
    		con.Open();
    	}
    
    	SqlDataAdapter da = null;		
    	DataTable dt = new DataTable();
    	if(comboBox1.Text == "EmployeeID")
    	{
    		da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeID like @employeeID", con);
    		da.SelectCommand.Parameters.AddWithValue("@employeeID", "%" + textBox5.Text + "%");
    		da.Fill(dt);
    	}
    	else if (comboBox1.Text == "EmployeeName")
    	{
    		da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeName like @employeeName", con);
    		da.SelectCommand.Parameters.AddWithValue("@employeeName", "%" + textBox5.Text + "%");
    		da.Fill(dt);
    	}
    	else
    	{
    	    
    	}
    
        dataGridView1.DataSource = dt;
      }
