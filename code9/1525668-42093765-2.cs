    public FindStudies_DTO_OUT FindStudies(FindStudies_DTO_IN findStudies_DTO_IN)
    {
        // Thread-safe collection
    	var ret = new ConcurrentBag<Study_C>()
    	
        // Loop cluster list and process each item in parallel and wait all process to finish. This handle the parallism better than task run
        Parallel.Foreach(Cluster, (sp) =>
        {
            var serviceAddress = sp.GetLibraryAddress(ServiceLibrary_C.PCM) + "/Exam.svc";
    		        
    		ExamClient examClient = new ExamClient(serviceAddress.GetBinding(), new EndpointAddress(serviceAddress), Token);
    		
    		try
    		{
    			examClient.Ping();				
                // declare result variable type outside try catch to be visible below				
    			var result = examClient.FindStudies(findStudies_DTO_IN);
    		}
    		catch(TimeoutException timeoutEx)
    		{
    			// abort examclient to dispose channel properly
    			Logging.Log(LoggingMode.Warning, "Timeout on FindStudies for:{0}, address:{1}", sp.Name, serviceAddress);
    		}
    		catch(FaultException fault)
    		{
    			Logging.Log(LoggingMode.Error, "FindStudies failed for :{0}, address:{1}, EXP:{2}", sp.Name, serviceAddress, fault.Exception.ToString());
    		}
    		catch(Exception ex)
    		{
    			// anything else
    		}
            // add exception type as needed for proper logging
            
    	    // use inverted if to reduce nested condition
    		if( result == null )
    			return null;
    		
    		var study_c = result.Studies.Select(x =>
    		{
    			x.StudyInstanceUID = string.Format("{0}|{1}", sp.Name, x.StudyInstanceUID);
    			x.InstitutionName = sp.Name;
    			return x;
    		}));
    		
    		// Thread-safe collection
    		ret.AddRange(study_c);      
        });
        
    	// for sorting i guess concurrentBag has orderby; if not working convert to list
        return new FindStudies_DTO_OUT(ret.Sort(findStudies_DTO_IN.SortColumnName, findStudies_DTO_IN.SortOrderBy));
    }
