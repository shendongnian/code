    query.SelectList(list => list
        .Select(t => t.ID).WithAlias(() => todoSummary.ID)
        .Select(t => t.Name).WithAlias(() => todoSummary.Name)
        .Select(t => t.Priority).WithAlias(() => todoSummary.Priority))
    .TransformUsing(Transformers.AliasToBean<TodoDTO>());
