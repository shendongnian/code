    bool successrun = true;
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
