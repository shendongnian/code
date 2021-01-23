    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Persons",
            columns: table => new
            {
                ID = table.Column<Guid>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Persons", x => x.ID);
            });
        migrationBuilder.CreateTable(
            name: "Prospects",
            columns: table => new
            {
                ID = table.Column<Guid>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prospects", x => x.ID);
                table.ForeignKey(
                    name: "FK_Prospects_Persons_ID",
                    column: x => x.ID,
                    principalTable: "Persons",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
            });
    }
