    // list of models, because you want ALL of them
    var managementModels = new List<CollectionsManagementViewModel>();
    var setupIds = _repository.GetAllYearSetupIds();
    foreach(var setupId in setupIds)
    {
       // new model created for each setup id
       var managementModel = _repository.GetOverdueBalances(page, pageLength,
                setupId.YearSetupId, balancefilter,
                sort, direction == Constants.ascending,
                spreadsheetType);
       managementModel.Title = title + " Management";
       managementModels.Add(managementModel); // add model to list
    }
    
    // pass collection to view
    return View("CollectionsManagement", managementModels);
