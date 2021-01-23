    //private NetSuiteService nsService = new DataCenterAwareNetSuiteService("login");
    //private TokenPassport createTokenPassport() { ... }
            
    private IEnumerable<DeletedRecord> DeletedRecordSearch()
    {
    	List<DeletedRecord> results = new List<DeletedRecord>();
    	int totalPages = Int32.MaxValue;
    	int currentPage = 1;
    
    	while (currentPage <= totalPages)
    	{
    		//You may need to reauthenticate here
    		nsService.tokenPassport = createTokenPassport();
    		
    		var queryResults = nsService.getDeleted(new GetDeletedFilter
    		{
    			//Add any filters here...
    			//Example
    			/*
    			deletedDate = new SearchDateField()
                        {
                            @operator = SearchDateFieldOperator.after,
                            operatorSpecified = true,
                            searchValue = DateTime.Now.AddDays(-49),
                            searchValueSpecified = true,
                            predefinedSearchValueSpecified = false,
                            searchValue2Specified = false
                        }
    			*/
    		}, currentPage);
    
    		currentPage++;
    		totalPages = queryResults.totalPages;
    
    		results.AddRange(queryResults.deletedRecordList);
    	}
    
    	return results;
    }
    
    private Tuple<string, string> SafeTypeCastName(
    	Dictionary<string, string> customList, 
    	BaseRef input)
    {
    	if (input.GetType() == typeof(RecordRef)) {
    		return new Tuple<string, string>(((RecordRef)input).name, 
    			((RecordRef)input).type.ToString());
    	}
    	//Not sure why "Last Sales Activity Record" doesn't return a type...
    	else if (input.GetType() == typeof(CustomRecordRef)) {
    		return new Tuple<string, string>(((CustomRecordRef)input).name, 
    			customList.ContainsKey(((CustomRecordRef)input).internalId) ? 
    			    customList[((CustomRecordRef)input).internalId] : 
                    "Last Sales Activity Record"));
    	}
    	else {
    		return new Tuple<string, string>("", "");
    	}
    }
    
    public Dictionary<string, string> GetListCustomTypeName()
    {
    	//You may need to reauthenticate here
    	nsService.tokenPassport = createTokenPassport();
    	
    	return
    		nsService.search(new CustomListSearch())
    			.recordList.Select(a => (CustomList)a)
    			.ToDictionary(a => a.internalId, a => a.name);
    }
    
    //Main code starts here
    var results = DeletedRecordSearch();
    var customList = GetListCustomTypeName();
    
    var demoResults = results.Select(a => new
    {
    	DeletedDate = a.deletedDate,
    	Type = SafeTypeCastName(customList, a.record).Item2,
    	Name = SafeTypeCastName(customList, a.record).Item1
    }).ToList();
