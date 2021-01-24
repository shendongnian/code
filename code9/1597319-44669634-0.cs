    string connectionString = "Data Source=localhost\\SqlExpress;" +
                    "Initial Catalog=MMABooks;Integrated Security=True";
    
    SqlConnection connection = new SqlConnection(connectionString);
    string selectStatement = "SELECT Customers.Name, Customers.City, States.StateName " +
                    "FROM Customers " +
                    "INNER JOIN States " +
                    "ON Customers.State = States.StateCode " +
                    "WHERE Name LIKE @Name";
    
     SqlCommand SelectCommand = new SqlCommand(selectStatement, connection);
     SelectCommand.Parameters.AddWithValue("@Name", TextBox1.Text.Trim() + "%");
    
     connection.Open();
      var dataAdapter = new SqlDataAdapter(SelectCommand);
      DataTable dt = new DataTable();
      dataAdapter.Fill(dt);
      GridView1.DataSource = dt;
      GridView1.DataBind();//you are missing this
