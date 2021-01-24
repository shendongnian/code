    private void create_user_username_box_Leave(object sender, EventArgs e)
    {
     // Add user/password to database when when someone leaves the area. 
     using (SqlConnection connection = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;"))
     {
         connection.Open();
         using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[information] (id,password) VALUES ("+create_user_username_textbox.Text+","+create_user_password_textbox.Text+");"))
         {
             command.Connection = connection;
             command.ExecuteNonQuery(); // System.Data.SqlClient.SqlException: 'Incorrect syntax near ')'.'
         }                
    }                
    }
