    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tests",
            columns: table => new
            {
                Code = table.Column<string>(nullable: false),
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                MyUniqueId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tests", x => x.Code);
            });
    
        migrationBuilder.CreateIndex(
            name: "IX_Tests_MyUniqueId",
            table: "Tests",
            column: "MyUniqueId",
            unique: true);
    }
