    #region Primenumbers
    private void btnPrimStart_Click(object sender, EventArgs e)
    {
    	if (!bgwPrim.IsBusy)
    	{
    		//Prepare ProgressBar and Textbox
    		int temp = (int)nudPrim.Value;
    		pgbPrim.Maximum = temp;
    		tbPrim.Text = "";
    		//Start processing
    		bgwPrim.RunWorkerAsync(temp);
    	}
    }
    private void btnPrimCancel_Click(object sender, EventArgs e)
    {
    	if (bgwPrim.IsBusy)
    	{
    		bgwPrim.CancelAsync();
    	}
    }
    private void bgwPrim_DoWork(object sender, DoWorkEventArgs e)
    {
    	int highestToCheck = (int)e.Argument;
    	//Get a reference to the BackgroundWorker running this code
    	//for Progress Updates and Cancelation checking
    	BackgroundWorker thisWorker = (BackgroundWorker)sender;
    	//Create the list that stores the results and is returned by DoWork
    	List<int> Primes = new List<int>();
    	
    	//Check all uneven numbers between 1 and whatever the user choose as upper limit
    	for(int PrimeCandidate=1; PrimeCandidate < highestToCheck; PrimeCandidate+=2)
    	{
    		//Report progress
    		thisWorker.ReportProgress(PrimeCandidate);
    		bool isNoPrime = false;
    		//Check if the Cancelation was requested during the last loop
    		if (thisWorker.CancellationPending)
    		{
    			//Tell the Backgroundworker you are canceling and exit the for-loop
    			e.Cancel = true;
    			break;
    		}
    		//Determin if this is a Prime Number
    		for (int j = 3; j < PrimeCandidate && !isNoPrime; j += 2)
    		{
    			if (PrimeCandidate % j == 0)
    				isNoPrime = true;
    		}
    		if (!isNoPrime)
    			Primes.Add(PrimeCandidate);
    	}
    	//Tell the progress bar you are finished
    	thisWorker.ReportProgress(highestToCheck);
    	//Save Return Value
    	e.Result = Primes.ToArray();
    }
    private void bgwPrim_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	pgbPrim.Value = e.ProgressPercentage;
    }
    private void bgwPrim_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	pgbPrim.Value = pgbPrim.Maximum;
    	this.Refresh();
    	if (!e.Cancelled && e.Error == null)
    	{
    		//Show the Result
    		int[] Primes = (int[])e.Result;
    		StringBuilder sbOutput = new StringBuilder();
    		foreach (int Prim in Primes)
    		{
    			sbOutput.Append(Prim.ToString() + Environment.NewLine);
    		}
    		tbPrim.Text = sbOutput.ToString();
    	}
    	else 
    	{
    		tbPrim.Text = "Operation canceled by user or Exception";
    	}
    }
    #endregion
