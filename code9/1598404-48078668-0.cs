    protected override MigrationStatement Generate(CreateTableOperation op)
    {
        MigrationStatement statement = base.Generate(op);
        if(/*Your condition */)
        {
            statement.Sql += $@"; {/*Your Sql*/};";
        }
        return statement;
    }
