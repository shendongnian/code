    private void Form1_Load(object sender, EventArgs e)
    		{
    			if (!CheckNetwork())
    			{
    				MessageBox.Show("No connection available");
    				this.Close();
    			}
    			else
    			{
    
    				MessageBox.Show("Network connection available");
    			}
    		}
