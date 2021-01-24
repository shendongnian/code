    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc GetStudentDetail");
            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnrollmentId = table.Column<int>(nullable: false),
                    FatherContact = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RollNumber = table.Column<string>(nullable: true),
                    SchoolClass = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false),
                    SsId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.Id);
                });
        }
