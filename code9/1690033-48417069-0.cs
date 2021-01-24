    private void OpenManagerConsole()
    {
        try
        {
            ShowLoader();
    
            Frame OpenScreen = new Frame();
            OpenScreen = homewindow.FindName("Main") as Frame;
			OpenScreenName = "Manager Console";
			Task.Factory.StartNew(() => {
				return new ManagerConsole();
			}).ContinueWith(t =>
			{
				OpenScreen.Content = t.Result;				
				HideLoader();
			}, TaskScheduler.FromCurrentSynchronizationContext());    
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
