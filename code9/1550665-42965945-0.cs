    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
    {
    	GameLoopStopSignal = false;
    	while (!GameLoopStopSignal)
    	{
    		//something like good old DoEvents()?
    		CoreApplication.MainView.CoreWindow.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);
    
    		await Task.Yield();
    		//Game Tick
    		Tick();
    	}
    });
