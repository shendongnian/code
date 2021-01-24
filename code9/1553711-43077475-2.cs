    migrationBuilder.CreateTable(
        name: "Cities",
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Cities", x => x.Id);
        });
    
    migrationBuilder.CreateTable(
        name: "ZipCodes",
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            CityId = table.Column<int>(nullable: true),
            Zip = table.Column<string>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_ZipCodes", x => x.Id);
            table.ForeignKey(
                name: "FK_ZipCodes_Cities_CityId",
                column: x => x.CityId,
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });
    
    migrationBuilder.CreateIndex(
        name: "IX_ZipCodes_CityId",
        table: "ZipCodes",
        column: "CityId",
        unique: true);
