    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foos", "Bar_Id", "dbo.Bars");
            DropIndex("dbo.Foos", new[] { "Bar_Id" });
            CreateTable(
                "dbo.FooBars",
                c => new
                    {
                        Foo_Id = c.Int(nullable: false),
                        Bar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Foo_Id, t.Bar_Id })
                .ForeignKey("dbo.Foos", t => t.Foo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bars", t => t.Bar_Id, cascadeDelete: true)
                .Index(t => t.Foo_Id)
                .Index(t => t.Bar_Id);
            
            // HERE:
            this.Sql("insert into FooBars select Id, Bar_Id from Foos");
            
            DropColumn("dbo.Foos", "Bar_Id");
        }
        ...
     }
