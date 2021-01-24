    private void button3_Click(object sender, EventArgs e)
    {
    	string SearchString = textBox3.text;
    	try
    	{
    		foreach (DataGridViewRow row in dataGridView1.Rows)
    		{
    			if (row.Cells[SearchColumn.SelectedIndex].Value.ToString().Equals(SearchString))
    			{
    				MessageBox.Show("Match Found");
    				//This will only pick up the first match not multiple…
    			}
    			else
    			{
    				MessageBox.Show("No Match");
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
