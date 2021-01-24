    private void button1_Click(object sender, EventArgs e)
	{
		int colIndex = dataGridView2.Columns["CheckBox"].Index;
		try
		{
			var rows = dataGridView2.Rows
				.Cast<DataGridViewRow>()
				.Where(row => row.Cells[colIndex].Value != null)
				.Where(row => (bool)row.Cells[colIndex].Value)
				.ToList();
			
			foreach(DataGridViewRow row in rows)
				insertRowData(row);
            
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
	
	private void insertRowData(DataGridViewRow row)
	{
		double montantValue = row.Cells["Montant"].Value != "" ? 
			Convert.ToDouble(row.Cells["Montant"].Value) : 0;
		int id_br = Convert.ToInt32(row.Cells["Id_bon_reception_marche"].Value);
		
		Program.cmd.Parameters.Clear();
		// change your sql to however you need to insert it
		Program.cmd.CommandText = "INSERT INTO tableName (montantColumn, idColumn) VALUES (@montant, @id);";
		Program.cmd.Parameters.AddWithValue("@montant", montantValue);
		Program.cmd.PArameters.AddWithValue("@id", id_br);
        Program.cmd.ExecuteNonQuery();
	}
