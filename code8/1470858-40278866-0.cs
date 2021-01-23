	for (int i = 0; i <= 10; i++)
	{
		DataGridViewRow fr = new DataGridViewRow();
		fr.CreateCells(dgvSample);
		DataGridViewButtonCell bc = new DataGridViewButtonCell();
		bc.FlatStyle = FlatStyle.Flat;
		
		if (i % 2 == 0)
		{
			bc.Style.BackColor = Color.Red;
		}   
		else
		{
			bc.Style.BackColor = Color.Green;
		}
		fr.Cells[0] = bc;
		dgvSample.Rows.Add(fr);
	}
