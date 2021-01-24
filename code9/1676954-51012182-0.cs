    protected override void Generate(CreateTableOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        base.Generate(operation, model, builder);
        foreach (var columnOperation in operation.Columns) //columnOperation is AddColumnOperation
        {
            //operation.FindAnnotation("MyAttribute")
        }
    }
