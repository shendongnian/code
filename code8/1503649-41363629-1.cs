	private ConcurrentBag<string> TotalProxies = new ConcurrentBag<string>();
	private async void CheckProxies()
	{
		lbl_Status.Text = "Checking"; //NB, invoking is omitted assuming that CheckProxies is called from the UI thread itself
		var tasks = TotalProxies.Select(CheckProxy);
		await Task.WhenAll(tasks);
	    lbl_Status.Text = "Idle";
	}
	
	private async Task<bool> CheckProxy(string p)
	{	
		bool working = await Task.Run(() => WebEngine.IsProxyWorking(p)); //would be better if IsProxyWorking itself uses async methods and returns a task, so Task.Run isn't needed. Don't know if it's possible to alter that function?
		if(working)
		{
			WorkingProxies.Add(p);
			workingp++; //Interlocked.Increment is not necessary because after the await we're back in the main thread
			lstv_Working.Items.Add(p);  //are these items cleared on a new run? 
			lbl_Working.Text = workingp.ToString();
		}
		checkedp++;
		lbl_Checked.Text = checkedp.ToString(); 
		return working;
	}
