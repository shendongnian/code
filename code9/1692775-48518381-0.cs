    private void btnRemoveCommand_Click(object sender, EventArgs e)
    {
        for (int i = listBox1.SelectedItems.Count; i >= 0; i--)
        {
			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand("DELETE FROM Commands WHERE commandName = @Command;", connection))
			{	
				connection.Open();
				//Add parameter with Add method - you may need to address the data type
				command.Parameters.Add("@Command", SqlDbType.VarChar, 50).Value = listBox1.SelectedItems[i];
				command.ExecuteNonQuery();
			}
			listBox1.Items.Remove(listBox1.SelectedItems[i]);   
        }
    }
