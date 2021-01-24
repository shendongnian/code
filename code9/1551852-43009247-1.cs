    private void button1_Click(object sender, EventArgs e)
    {
        // retrieve connection from configuration file
        // requires a reference to System.Configuration assembly in your project
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["My_Connection"].ConnectionString;
        //alternatively, hardcode connection string (bad idea!)
        //string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        using(SqlConnection connection = new SqlConnection(connectionString))
        using(SqlCommand command = new SqlCommand("INSERT INTO person (name, lastname, phone) VALUES(@name, @lastname, @phone)", connection))
        {
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@lastname", txtLastname.Text);
            command.Parameters.AddWithValue("@phone", Convert.ToInt32(txtPhone.Text));
            connection.Open();
            command.ExecuteNonQuery();          
        }
        MessageBox.Show("Successful");
    }
