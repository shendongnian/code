    private async void TriggerWeekChanged(Week currentWeek, CancellationTokenSource tokenSource)
    {
    	tokenSource.Cancel();
		try
		{
			var loadDataTask = Task.Run(() => LoadDataForSelectedWeek(currentWeek, tokenSource.Token), tokenSource.Token); //Split into multiple methods
		}
		catch(OperationCanceledException ex)
		{
			//Cancelled
		}
    }
    
