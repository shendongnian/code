    using (var db = new MyContext())
    {
        var services = ((IInfrastructure<IServiceProvider)db).Instance;
        var model = services.GetService<IModel>();
        var differ = services.GetService<IMigrationsModelDiffer>();
        var generator = services.GetService<IMigrationsSqlGenerator>();
        var sqlHelper = services.GetService<ISqlGenerationHelper>();
        var operations = differ.GetDifferences(null, model);
        var commands = generator.Generate(operations, model);
        var builder = new StringBuilder();
        foreach (var command in commands)
        {
            builder
                .Append(command.CommandText)
                .AppendLine(sqlHelper.BatchTerminator);
        }
        // Here is the SQL.
        var sql = builder.ToString();
    }
