    protected override void Up(MigrationBuilder migrationBuilder)
    {
        if (migrationBuilder.ActiveProvider == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                ...);
        }
        else
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                schema: "Common",
                ...);
        }
    }
