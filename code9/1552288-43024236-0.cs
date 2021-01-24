	private void EntTimer_Elapsed(object Sender, System.Timers.ElapsedEventArgs e)
	{
		int columnIndex = dgV.CurrentCell.ColumnIndex;
		int rowIndex = dgV.CurrentCell.RowIndex;
		var TheDate = DateTime.Now;
		var dgvDate = Convert.ToDateTime(dgV.Rows[rowIndex].Cells["Tarih"].Value);
		if (TheDate > dgvDate)
		{
			DeleteMet();
		}
		EntTimer.AutoReset = true;
		dgv.Refresh();//ADD THIS LINE
	}
