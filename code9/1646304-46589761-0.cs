    private void deleteitems()
    {    
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            connection.Open();
            foreach(var index in listView1.SelectedIndicies)
            {
                // Modify this to get the 'cashier_id' from you listView at the specified row index...
                // You should also consider using a prepared query...
                string query = "delete from Tbl_Cashier where Cashier_ID = '" + index +"' ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // consider checking the return value here if the delete command was successful
                    command.ExecuteNonQuery();
                }
            }
        }
        MessageBox.Show("You will see the new data with your next restart of the application", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
