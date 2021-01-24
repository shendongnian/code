     private bool AuthenticateUser() 
         {
            // rather than picking up variable names, I am picking up the information from the text boxes on the screen.
            bool retVal = false;
            string cs1 = "Data Source=yourdatasource;Initial Catalog=yourcat;Persist Security Info=True;User ID=" + txtLogin1.Text.Trim() + ";Password=" + txtPW1.Text.Trim() + ";";
            string cs2 = "Data Source=yourdatasource;Initial Catalog=yourcat;Persist Security Info=True;User ID=" + txtLogin2.Text.Trim() + ";Password=" + txtPW2.Text.Trim() + ";";
            try
            {
                using (var connection = new SqlConnection(cs1))
                {
                    connection.Open();
                    retVal = true;
                }
            }
            catch (SqlException e2)
            {
                MessageBox.Show("User 1 Failed " + e2.ToString());
            }
            
            try
            {
                using (var connection = new SqlConnection(cs2))
                {
                    connection.Open();
                    retVal = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("User 2 Failed "+ex.ToString());
            }
            if (retVal)
                { MessageBox.Show("Passed"); }
            else
                { MessageBox.Show("Please Try"); }
            return retVal;
        }
    }
