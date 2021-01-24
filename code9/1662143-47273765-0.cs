    @model IEnumerable<PersonModel>
    
    @(Html
        .Grid(Model)
        .Build(columns =>
        {
            columns.Add(model => model.Name).Titled("Name");
            columns.Add(model => model.Surname).Titled("Surname");
        })
        .Attributed(new { id = "your_id" })
    )
