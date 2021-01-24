    private void button1_Click(object sender, EventArgs e)
    {
        int colIndex = dataGridView2.Columns["CheckBox"].Index;
        try
        {
            var values = dataGridView2.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells[colIndex].Value != null)
                .Where(row => (bool)row.Cells[colIndex].Value)
                .Select(row => row.Cells["Montant"].Value != "" ? 
                   Convert.ToDouble(row.Cells["Montant"].Value) : 0)
                .ToList();
				
            foreach(double d in values)
                insertDouble(d);
	            
            MessageBox.Show("c'est ajouté avec succés");
        }
        catch (FormatException)
        {
            MessageBox.Show("Only input numbers into the table!", 
                "Only Numbers", MessageBoxButtons.OK);
        }
        catch (Exception)
        {
            MessageBox.Show("There was an error while saving!", 
                "Error", MessageBoxButtons.OK);
        }
    }
		
    private void insertDouble(double d)
    {
        Program.cmd.Parameters.Clear();
        // change your sql to however you need to insert it
        Program.cmd.CommandText = "INSERT INTO tableName (columnName) VALUES (@double);";
        Program.cmd.Parameters.AddWithValue("@double", d);
        Program.cmd.ExecuteNonQuery();
    }
