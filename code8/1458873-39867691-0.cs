     private void Btn_Click(object sender, System.EventArgs e)
    {
        txt.Text = "Connecting...";
    
    	//do your sql call in a new task
        Task.Run(() => { 
    		if (sql.testConnection())
    		{
    			//text is part of the UI, so you need to run this code in the UI thread
    			RunOnUiThread((() => txt.Text = "Connected"; );
    				
    			load();
    		}	
    		else{
    			//text is part of the UI, so you need to run this code in the UI thread
    			RunOnUiThread((() => txt.Text = "SQL Connection error"; );
    		}
        });	
            
    }
