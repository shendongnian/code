    using (SqlConnection conn = new SqlConnection(your-connection-string)) {
    conn.Open();
    // 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("your-procedure-name", conn);
    // 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;
    // 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@Username", textBox1.Text));
    cmd.Parameters.Add(new SqlParameter("@Password", textBox2.Text));
    // execute the command
    using (SqlDataReader result = cmd.ExecuteReader()) {
        // iterate through results, printing each to console
        while (result .Read())
        {
          // Name  and Password Should Match with your proc col name 
          var userName  = result["Name"].toString();
          var password  = result["password"].toString();
        
        }
    }
     }
