	foreach (var row in dataGridView1.Rows)
	{
        partData.partID = Convert.ToString(row.Cells[0].Value);
        partData.productName = Convert.ToString(row.Cells[1].Value);
        partData.partDescription = Convert.ToString(row.Cells[2].Value);
        partData.unitPrice = Convert.ToString(row.Cells[3].Value);
        partData.quantity = Convert.ToString(row.Cells[4].Value);
        partData.partNote = Convert.ToString(row.Cells[5].Value);
	
        MessageBox.Show(PerformRequestUpdatePriority("http://dcosgrove04.students.cs.qub.ac.uk/importParts.php?", username, partData.partID, partData.productName, partData.partDescription, partData.unitPrice, partData.quantity, partData.partNote));
        Console.WriteLine(username);
	}
