    var results = new List<TypeModel>();
    foreach (var item in allTypes.GroupBy(type => type.CodeType))
    {
        var conditionsList = new List<ConditionModel>();
        foreach (var item2 in item.GroupBy(x => new { x.ConditionType, x.Description }))
        {
            conditionsList.Add(new ConditionModel
            {
                Type = item2.Key.ConditionType,
                Description = item2.Key.Description,
                Questions = item2.Select(x => new QuestionModel { Type = x.QuestionType }).ToList()
            });
        }
        results.Add(new TypeModel
        {
            Type = item.Key,
            Conditions = conditionsList
        });
    }
