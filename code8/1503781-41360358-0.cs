    // Create progress printing and querying tasks
    Task progressPrintTask = new Task(() =>
    	{
    
    		IJob jobQuery = null;
    		do
    		{
    			var progressContext = new CloudMediaContext(_accountName, _accountKey);
    			jobQuery = progressContext.Jobs.Where(j => j.Id == job.Id).First();
    			textBox2.Invoke(() => textBox2.AppendText(string.Format("{0}\t{1}\t{2}", DateTime.Now, jobQuery.State, jobQuery.Tasks[0].Progress)));
    			Thread.Sleep(10000);
    		}
    		while (jobQuery.State != JobState.Finished &&
    			   jobQuery.State != JobState.Error &&
    			   jobQuery.State != JobState.Canceled);
    	});
    progressPrintTask.Start();
