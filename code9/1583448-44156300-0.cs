    int countCharacters()
        {
    
            int count = 0;
            using (StreamReader reader= new StreamReader("D:\\Data.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
                return count; 
        }
    	
    	
        private  void btnProcessFIle_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(countCharacters);
            task.Start();
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    		task.ContinueWith(count =>{
    			   
                     lblCount.Text = "No. of characters in file=" +Environment.NewLine+ count.ToString();	
    		}, uiScheduler);
        }
