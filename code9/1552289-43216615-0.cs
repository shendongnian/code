    System.Timers.Timer EntTimer = new System.Timers.Timer(1000);
            private void Timer()
            {
        		EntTimer.Elapsed += EntTimer_Elapsed;
        		EntTimer.Enabled = true;
        		EntTimer.Start();
        	}
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
        	}
        	DeleteMet()
        
        	private void DeleteMet()
        	{
               int rowIndex = dgV.CurrentCell.RowIndex;
               string SelectRow =dgV.Rows[rowIndex].Cells[0].Value.ToString();
        		conn.Open();
        		OleDbCommand cmd = new OleDbCommand("Delete from Timer Where ID=@Id", conn);
        		cmd.Parameters.Add(new OleDbParameter("@Id", SelectRow));
        		if (cmd.ExecuteNonQuery() == 1)
        		{
        			int rowIndex = dgV.CurrentCell.RowIndex;
        			string message = txtNotes.Text = dgV.Rows[rowIndex].Cells["Notes"].Value.ToString();
        			MessageBox.Show(message, "Hatırlatma !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        		}
        		conn.Close();
        		MainShow();
        		FirstRowHL();
        	}
