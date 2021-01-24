    protected override void Up(MigrationBuilder migrationBuilder)
    {
        const String sql = "CREATE TYPE [dbo].[UserTableType] AS TABLE (Id bigint, Name nvarchar(max))";
        migrationBuilder.Sql(sql);
    }
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP TYPE IF EXISTS [UserTableType]");
    }
