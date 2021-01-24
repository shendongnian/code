    @model IEnumerable<PersonModel>
    
    @(Html
    .Grid(Model)
    .Build(columns =>
    {
        columns.Add(model => model.Name).Titled("Name");
        columns.Add(model => model.Surname).Titled("Surname");
        columns.Add(model => model.Age).Titled("Age");
        columns.Add(model => model.Birthday).Titled("Birth date");
        columns.Add(model => model.IsWorking).Titled("Employed");
    })
    .Filterable()
    .Sortable()
    .Pageable()
    )
