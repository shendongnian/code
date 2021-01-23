    migrationBuilder.CreateTable(
        name: "Tags",
        columns: table => new
        {
            Id = table.Column<long>(nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            AddressId = table.Column<long>(nullable: true),
            Name = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Tags", x => x.Id);
            table.ForeignKey(
                name: "FK_Tags_Addresses_AddressId",
                column: x => x.AddressId,
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        });
