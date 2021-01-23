    var parameter = Expression.Parameter(typeof(StagedModel), "s");
    Expression stage = null;
    if (model.ClientId != null)
    {
    	stage = Expression.Equal(Expression.PropertyOrField(parameter, "ClientId"), Expression.Constant(model.ClientId));
    }
    if (model.CategoryIds != null && model.CategoryIds.Any())
    {
    	var stageIds = new List<int> { 1, 2, 3 };    
    	Expression contains = null;
    	foreach (var id in stageIds)
    	{
    		var equals = Expression.Equal(Expression.Constant(id), Expression.PropertyOrField(parameter, "Id"));
    		contains = contains == null ? equals : Expression.OrElse(contains, equals);
    	}
    
    	stage = stage == null ? stage : Expression.AndAlso(stage, contains);
    }    
    var lambda = Expression.Lambda<Func<StagedModel, bool>>(stage, parameter);
    Stages = unitOfWork.Stages.GetStagesPagedList(1, PerPage, stage);
