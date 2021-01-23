    migrationBuilder.CreateTable(
        name: "Chicken",
        columns: table => new
        {
            ChickenId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            IsRooster = table.Column<bool>(nullable: false),
            LastChangeByFarmerId = table.Column<int>(nullable: false),
            LastChangeTimestamp = table.Column<DateTime>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Chicken", x => x.ChickenId);
            table.ForeignKey(
                name: "FK_Chicken_Farmer_LastChangeByFarmerId",
                column: x => x.LastChangeByFarmerId,
                principalTable: "Farmer",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);
        });
    
    migrationBuilder.CreateTable(
        name: "Cow",
        columns: table => new
        {
            CowId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            LastChangeByFarmerId = table.Column<int>(nullable: false),
            LastChangeTimestamp = table.Column<DateTime>(nullable: false),
            Name = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Cow", x => x.CowId);
            table.ForeignKey(
                name: "FK_Cow_Farmer_LastChangeByFarmerId",
                column: x => x.LastChangeByFarmerId,
                principalTable: "Farmer",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);
        });
