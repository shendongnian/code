    var controller = new MastersController();
    var actualResults = _masterListRepo.GetAll().ToList();
    
    var resultsFromController = controller.GetAllMasterList(); //This is now an IEnumerable<Master>)
    
