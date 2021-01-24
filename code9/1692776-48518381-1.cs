    private void btnRemoveCommand_Click(object sender, EventArgs e)
    {
		var table = new DataTable();
		table.Columns.Add("Value", typeof(string));
        for (int i = listBox1.SelectedItems.Count; i >= 0; i--)
        {
			table.Rows.Add(new []{listBox1.SelectedItems[i]});
			listBox1.Items.Remove(listBox1.SelectedItems[i]);   
        }
		using (var connection = new SqlConnection(connectionString))
		using (var command = new SqlCommand("DELETE FROM Commands WHERE commandName IN (SELECT Value FROM @Commands);", connection)
		{	
			connection.Open();
			command.Parameters.Add(new SqlParameter("@Commands", SqlDbType.Structured) { Value = table, TypeName = "dbo.ListOfInt" });
			command.ExecuteNonQuery();
		}
    }
