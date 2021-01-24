    private void timer1_Tick(object sender, EventArgs e)
    {
        if(!m_bDisplayed)
            GetTimeStamp();
    }
    private void GetTimeStamp()
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            TimeSpan span = (DateTime.Now - Convert.ToDateTime(row.Cells[2].Value));
    
            String.Format("{0}, {1}, {2}",
                span.Hours, span.Minutes, span.Seconds);
    
            row.Cells[3].Value = span.ToString(@"hh\:mm\:ss").Trim();
    
            if (Convert.ToDateTime(row.Cells[3].Value) >= DateTime.Parse("0:05:00")
                && Convert.ToDateTime(row.Cells[3].Value) <= DateTime.Parse("0:19:59") 
                && row.Cells[1].Value.ToString().Trim() == "4 - Needs to be solved")
            {
    
                    MessageBox.Show("There is one or more tasks to be solved", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_bDisplayed = true;
            }
        }
    }
