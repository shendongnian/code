    migrationBuilder.CreateTable(
    	name: "ZipCodes",
    	columns: table => new
    	{
    		Id = table.Column<int>(nullable: false)
    			.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
    		Zip = table.Column<string>(nullable: false)
    	},
    	constraints: table =>
    	{
    		table.PrimaryKey("PK_ZipCodes", x => x.Id);
    	});
    
    migrationBuilder.CreateTable(
    	name: "Cities",
    	columns: table => new
    	{
    		Id = table.Column<int>(nullable: false)
    			.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
    		ZipCodeId = table.Column<int>(nullable: false)
    	},
    	constraints: table =>
    	{
    		table.PrimaryKey("PK_Cities", x => x.Id);
    		table.ForeignKey(
    			name: "FK_Cities_ZipCodes_ZipCodeId",
    			column: x => x.ZipCodeId,
    			principalTable: "ZipCodes",
    			principalColumn: "Id",
    			onDelete: ReferentialAction.Cascade);
    	});
    
    migrationBuilder.CreateIndex(
    	name: "IX_Cities_ZipCodeId",
    	table: "Cities",
    	column: "ZipCodeId");
