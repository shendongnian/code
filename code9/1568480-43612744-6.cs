    int g;
    bool UserExists = false;
    switch(Department_cmbBx.SelectedItem.ToString())
    {
        case "Office":
           g = 1;
           break;
        case "Stores":
           g = 2;
           break;
        case "Workshop":
           g = 3;
           break;
        case "Management":
           g = 4;
           break;
        case "Admin":
           g = 5;
           break;   
        default:
           MessageBox.Show("error: an invalid value.");
           break;
    }
           
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        using (OleDbCommand command = new OleDbCommand("select [Username] from LoginTable where Username=@Username" , connection))
        {
            command.Parameters.Add("@Username", Username_txtBx.Text); 
            connection.Open();
            
            using(OleDbDataReader reader = command.ExecuteReader())
            {
                // If at least 1 row was returned, this means the user exists in the table.
                while (reader.Read())
                {
                    UserExists = true;
                }
            }    
            if (!UserExists) 
            {
                // The user does not exists - you can create it.
                command.Parameters.Clear();
                command.CommandText = "insert into LoginTable([Username],[Password],[Group]) values (@Username,@Username,@G)";
                command.Parameters.Add("@Username", Username_txtBx.Text); 
                command.Parameters.Add("@Password", "password"); 
                command.Parameters.Add("@G", g);
                command.ExecuteNonQuery();
            }
            else
            {
                // Show an error message - the user already exists
                MessageBox.Show("The user you eneterd already exists.");
            }
        }
    }
