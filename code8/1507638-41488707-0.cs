    // This would be in the external assembly
    public MyReturnValue ProcessFile(Action<double> progressDelegate)
    {
    	foreach(var line in file)
    	{
    		progressDelegate?.Invoke(myCalculatedProgress)
    	}
    }
    
    // This would be in the app
    
    var progDelegate = new Action<double>((progress) => ViewModel.Progress = progress);
    ExternalLibrary.ProcessFile(progDelegate);
