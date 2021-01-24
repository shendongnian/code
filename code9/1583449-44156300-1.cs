        private  void btnProcessFIle_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(countCharacters);
            task.Start();
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    		task.ContinueWith(count =>{
    			     lblCount.BeginInvoke(()=>{
                         lblCount.Text = "No. of characters in file=" +Environment.NewLine+ count.ToString();
                     });
	
    		});
        }
