    migrationBuilder.CreateTable(
        name: "User",
        columns: table => new
        {
            UserId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Email = table.Column<string>(nullable: true),
            Name = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_User", x => x.UserId);
        });
    
    migrationBuilder.CreateTable(
        name: "Account",
        columns: table => new
        {
            AccountId = table.Column<int>(nullable: false),
            CreatedDateTime = table.Column<DateTime>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Account", x => x.AccountId);
            table.ForeignKey(
                name: "FK_Account_User_AccountId",
                column: x => x.AccountId,
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        });
