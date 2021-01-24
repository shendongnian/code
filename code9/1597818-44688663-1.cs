    public partial class DeleteStatusFKFromBorrowedProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKeyConstraint(); // dropping FK constraint first
            DropForeignKey("dbo.BorrowedProperty", "StatusId", "dbo.codeStatus");
            DropIndex("dbo.BorrowedProperty", new[] { "StatusId" });
            DropColumn("dbo.BorrowedProperty", "StatusId"); // drop column at last
        }
    }
