    return View("CollectionsManagement", 
    	new OverpayViewModel { 
    		CollectionsManagementViewModels = 
    			_repository
    			.GetAllYearSetupIds()
    			.Select(ysi => _repository.GetOverdueBalances(
    				type,
    				page,
    				pageLength,
    				ysi.YearSetupId,
    				balanceFilter,
    				spreadsheetType) 	// Assuming the sort is optional
    			.OrderBy(vm => vm.Year)	// Assuming that the vm has a more sensible year property to sort numerically
    	});
    	
