    string settings = ""; // variable type should be same with return type of GetSettings()
    
    public void StartProcess() 
    {
    	if (successrun == true)
    	   settings = GetSettings();
    
    	successrun = true;
    	//set successran = false on any error on the following mwthods
    	CopyFiles(settings);
    	var listOfData = ReadFile(settings);
    	SaveListOfData(listOfData);
    }
    
    void AnyMethodCallsStartProcessInLoop()
    {
    	int numberOfProcesses = GetNumberOfProcesses();
    	int i = 0;
    	bool procSuccess = true; 
    	while ( i <= numberOfProcesses)
    	{
    		StartProcess();
    		if (procSuccess == true)
    			i++;
    	}
    }
