    public override void Up()
        {
            DropForeignKey("dbo.PersonModel", "TeamModel_TeamId", "dbo.TeamModel");
            DropIndex("dbo.PersonModel", new[] { "TeamModel_TeamId" });
            RenameColumn(table: "dbo.PersonModel", name: "TeamModel_TeamId", newName: "TeamModelRefId");
            DropPrimaryKey("dbo.PersonModel");
            AddPrimaryKey("dbo.PersonModel", "IdPerson");
            CreateIndex("dbo.PersonModel", "TeamModelRefId");
            AddForeignKey("dbo.PersonModel", "TeamModelRefId", "dbo.TeamModel", "TeamId", cascadeDelete: true);
            DropColumn("dbo.PersonModel", "PersonId");
            AddColumn("dbo.PersonModel", "IdPerson", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PersonModel", "TeamModelRefId", c => c.Int(nullable: false));
        }
