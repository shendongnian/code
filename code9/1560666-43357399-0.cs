    private void btnSynchronize_Click(object sender, EventArgs e)
    
            {
               
    //Create a MySQL connection string.
    string connectionString="Server=localhost;Database[database_name];Uid=root;Password =your password; ";
     
    MySqlConnection db_connect= new MySqlConnection(connectionString);
                
    db_connect.Open();
            }
