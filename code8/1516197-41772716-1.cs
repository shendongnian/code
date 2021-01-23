    var predicate = PredicateUtils.Null<StageModel>();
    
    if(model.ClientId != null)
    {
        predicate = predicate.And(s => s.ClientId == model.ClientId);
    }
    
    if (model.CategoryIds != null && model.CategoryIds.Any())
    {
        var stageIds = new List<int>{ 1, 2, 3 }; // this will be dynamically generated
    
        predicate = predicate.And(s => stageIds.Contains(s.Id));
    }
    
    Stages = unitOfWork.Stages.GetStagesPagedList(1, PerPage, predicate);
    
    ... 
    ...
