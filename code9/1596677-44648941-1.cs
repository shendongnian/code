    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {                
    	if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
    	{
    		var index = e.KeyCode == Keys.Up ? -1 : e.KeyCode == Keys.Down ? 1 : 0;
    		var rowIndex = dataGridView1.CurrentCell.RowIndex + index;
    		if (rowIndex > -1)
    		{
    			bool pingable = false;
    			Ping pinger = new Ping();
    
    			var row = dataGridView1.Rows[rowIndex];
    			if (row != null)
    			{
    				PingReply reply = pinger.Send(row.Cells[0].Value.ToString());
    
    				txtIP.Text = row.Cells[0].Value.ToString();
    				txtUser.Text = row.Cells[1].Value.ToString();
    				txtComputer.Text = row.Cells[2].Value.ToString();
    				txtUnity.Text = row.Cells[3].Value.ToString();
    				txtSession.Text = row.Cells[4].Value.ToString();
    				if (pingable = reply.Status == IPStatus.Success)
    				{
    					pictureBoxGreen.Show();
    					pictureBoxRed.Hide();
    				}
    				else if (pingable = reply.Status == IPStatus.TimedOut)
    				{
    					pcGreen.Hide();
    					pcRed.Show();
    				}
    			}
    		}
    	}
    }
