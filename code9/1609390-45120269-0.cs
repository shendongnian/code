    private int check = 0;
    private void button1_Click(object sender, EventArgs e)
    {
    	this.button1.Text = "Hide";
    
    	if (check == 0)
    	{
    		for (int i = 350; i <= 824; i += 2)
    		{
    			this.Size = new Size(i, 507);
    			Thread.Sleep(1);
    			this.CenterToScreen();
    		}
    		check = 1;
    
    
    	}
    
    	else if (check == 1)
    	{
    		this.button1.Text = "Key";
    
    		for (int i = 824; i >= 351; i -= 2)
    		{
    			this.Size = new Size(i, 507);
    			Thread.Sleep(1);
    			this.CenterToScreen();
    		}
    		check = 0;
    	}
    }
